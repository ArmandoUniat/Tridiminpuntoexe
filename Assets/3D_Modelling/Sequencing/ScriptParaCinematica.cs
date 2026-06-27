using UnityEngine;
using UnityEngine.SceneManagement;  

public class ScriptParaCinematica : MonoBehaviour
{


    [SerializeField]private string nombreSiguienteEscena = "MenuPrincipal";
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public void CambiarAlJuego() {     
        
        
        UnityEngine.SceneManagement.SceneManager.LoadScene(nombreSiguienteEscena);
    }
    void Start()



    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CambiarAlJuego();
    }
}
