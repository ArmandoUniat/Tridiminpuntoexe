using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnSpots;
    public GameObject page;
    private int randomSpawnSpot;

    public float tiempoVisible = 5f;
    public float tiempoOculto = 5f;
    public Transform spawn1;

    EnemigoTracking enemyT;


    void Start()
    {
        enemyT = GetComponent<EnemigoTracking>();
        StartCoroutine(ShowNHide());
    }

    IEnumerator ShowNHide()
    {
        Show();

        yield return new WaitForSeconds(tiempoVisible);

        Teleport();

        yield return new WaitForSeconds(tiempoOculto);

        StartCoroutine(ShowNHide());
    }

    void Show()
    {
        bool Chasing = enemyT.isChasing;

        if(Chasing == false)
        {
            Teleport();
        }
        page.SetActive(true);
    }

    

    void Teleport()
    {
        int numRand = Random.Range(0, spawnSpots.Length);
        page.transform.position = spawnSpots[numRand].position;
      

        //Transform spawns = spawnSpots[numRand];
        Debug.Log("Esto se repite cada 5 segundos");
        return;
    }
}