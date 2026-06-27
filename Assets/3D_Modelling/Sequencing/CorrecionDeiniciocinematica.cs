using UnityEngine;
using System.Collections;



public class CorrecionDeiniciocinematica : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ResetearTargetDisplay());
    }

    // Update is called once per frame

    IEnumerator ResetearTargetDisplay()
    {
        Camera camarita = GetComponent<Camera>();

        
        int displayOriginal = camarita.targetDisplay;

        
        yield return new WaitForEndOfFrame();

        
        camarita.targetDisplay = 1;

        
        yield return null;


        camarita.targetDisplay = 0;

        
        camarita.targetDisplay = displayOriginal;
    }
    void Update()
    {
        
    }
}
