using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMechanics : MonoBehaviour
{
    
    public Animator anim;

    public Transform playerTransform;
    private NavMeshAgent agent;
    public Animator enemigoanim;

    public float attackRange = 1.5f;
    public float attackCooldown = 2f;
    private float nextAttackTime = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Animator animator = GetComponent<Animator>();
        Animator enemigoanim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {   

            anim.SetTrigger("Damage");
            Debug.Log("Trigger");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (agent.remainingDistance > agent.stoppingDistance)
        {

            
            enemigoanim.SetBool("InMove", true);
        }
        else
        {
            enemigoanim.SetBool("InMove", false);
        }
    }
}
