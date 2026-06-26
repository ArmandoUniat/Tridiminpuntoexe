using UnityEngine;

public class FlashMechanic : MonoBehaviour
{

    public GameObject Enemigo;
    public SpawnManager spawn;




    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Flash"))
        {

            spawn.Teleport();
            Debug.Log("Desaparecio el pibe");
            
        }


    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
