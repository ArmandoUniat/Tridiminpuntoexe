using System.Collections;
using UnityEngine;

public class EnemyMechanics : MonoBehaviour
{
    
    public Animator anim;  

// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Animator animator = GetComponent<Animator>();
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
        
    }
}
