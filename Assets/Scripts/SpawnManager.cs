using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageGeneration : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform[] spawnSpots;
    public GameObject Page;
    private int randomSpawnSpot;
    private int x = 0;
    void Start()
    {
        randomSpawnSpot = Random.Range(0, spawnSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        PageGen();
    }

    void PageGen()
    {
        randomSpawnSpot = Random.Range(0, spawnSpots.Length);
        while (x <= 9)
        {


            Instantiate(Page, spawnSpots[randomSpawnSpot].position, Quaternion.identity);
            x++;
        }
    }
}