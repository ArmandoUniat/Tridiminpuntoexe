using UnityEngine;

public class FlashMechanic : MonoBehaviour
{

    public GameObject Enemigo;




    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Flash"))
        {

            Enemigo.SetActive(false);
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
