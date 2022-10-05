using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSpawner : MonoBehaviour
{
    private bool allowSpawn;
    
    public GameObject[] spawnGameObject; // The variable for the chosen object or objects to spawn.
    public GameObject[] spawningposition;
    [Header("Spawn timer")]

    [HideInInspector]
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;

    [Header("Number of Gamebjects in scene")]
    [SerializeField] private int totalObjects;
    public int currentObjects;


    [Header("Values for the spawning position")]
    [SerializeField] private float xAxis;
    [SerializeField] private float zAxis;
    [SerializeField] private float yAxis;
    [SerializeField] private float xAxisVertically;
    [SerializeField] private float zAxisVertically;
    void Update()
    {
        Spawn();
        spawnWait -= 1 * Time.deltaTime;
    }
    
    void Spawn()
    {
        if (allowSpawn)
        {
            // Takes and cycles through the random indexes of the items in the array.
            int randimIndex = Random.Range(0, spawnGameObject.Length);

            // Randomises the spawn position with the x/y/z axis also horizontially and vertically.
            Vector3 randomSpawnPosition = new Vector3(Random.Range(xAxis, zAxis), yAxis, Random.Range(xAxisVertically, zAxisVertically));

            if (currentObjects < totalObjects && spawnWait <= 0)
            {
                //Random time
                spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
                //Spawn object
                Instantiate(spawnGameObject [randimIndex], randomSpawnPosition, Quaternion.identity);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        allowSpawn = other.CompareTag("Player");
    }
}
