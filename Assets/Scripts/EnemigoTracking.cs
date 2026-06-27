using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoTracking : MonoBehaviour
{
    [Header("References")]
    public Transform player;

    [Header("Ranges")]
    public float rangoDeteccion = 25.0f;
    public float stopDistance = 1.6f;

    [Header("Speed")]
    public float chaseSpeed = 3.8f;

    private NavMeshAgent agent;

    public bool isChasing = false;

    public float stunDuration = 2f;
    bool isStunned = false;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        if (agent == null)
        {
            Debug.LogError("Falta NavMeshAgent en el enemigo.");
            enabled = false;
            return;
        }

        agent.stoppingDistance = stopDistance;
        agent.speed = chaseSpeed;

        agent.ResetPath();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Flash") && !isStunned)
        {
            StartCoroutine(StunRoutine());
        }
    }

    IEnumerator StunRoutine()
    {
        isStunned = true;

        if(agent != null)
        {
            agent.isStopped = true;
        }

        yield return new WaitForSeconds(stunDuration);

        if(agent != null)
        {
            agent.isStopped = false;
        }

        isStunned = false;
    }
    void Update()
    {
        if (player == null) return;

        float dist = Vector3.Distance(transform.position, player.position);

        if (dist <= rangoDeteccion)
        {
            isChasing = true;

            agent.SetDestination(player.position);

            if (dist <= stopDistance + 0.2f)
            {
                agent.ResetPath();
                FaceTarget(player.position);
            }
        }
        else
        {
            // Fuera del radio: quieto
            agent.ResetPath();
        }
    }

    private void FaceTarget(Vector3 targetPos)
    {
        Vector3 dir = targetPos - transform.position;
        dir.y = 0f;
        if (dir.sqrMagnitude < 0.001f) return;

        Quaternion look = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, look, Time.deltaTime * 8f);
    }

}
