using UnityEngine;
using UnityEngine.SceneManagement;  

public class ScriptParaCinematica : MonoBehaviour
{


    private float tiempoEnPantalla = 0f;
    public string nombreSiguienteEscena = "EscenaInGame";
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public void CambiarAlJuego() {     
        
        
        UnityEngine.SceneManagement.SceneManager.LoadScene(nombreSiguienteEscena);
    }
    void Start()



    {
        
    }

 
    void Update()
   {
        tiempoEnPantalla += Time.deltaTime;

        if (tiempoEnPantalla > 1f && Input.anyKeyDown)
        {
            CambiarAlJuego();
        }
    }
}
