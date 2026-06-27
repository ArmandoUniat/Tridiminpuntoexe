using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnSpots;
    public GameObject page;
    private int randomSpawnSpot;

    public float tiempoVisible = 5f;
    public float tiempoOculto = 5f;
    public Transform spawn1;

    public EnemigoTracking enemyT;


    void Start()
    {
        if(enemyT != null)
        {
            Debug.Log(enemyT);
        }

        StartCoroutine(ShowNHide());
    }

    IEnumerator ShowNHide()
    {
        bool Chasing = enemyT.isChasing;
        if (Chasing == false)
        {
            Show();

            yield return new WaitForSeconds(tiempoVisible);

            Teleport();

            yield return new WaitForSeconds(tiempoOculto);

            StartCoroutine(ShowNHide());
        }
    }

    void Show()
    {
        Teleport();
        page.SetActive(true);
    }

    public void Teleport()
    {
        int numRand = Random.Range(0, spawnSpots.Length);
        page.transform.position = spawnSpots[numRand].position;
      

        //Transform spawns = spawnSpots[numRand];
        Debug.Log("Esto se repite cada 5 segundos");
        return;
    }
}