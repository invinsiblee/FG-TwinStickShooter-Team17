using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomSpawner : MonoBehaviour
{
    public GameObject[] spawnGameObject; // The variable for the chosen object or objects to spawn.
    [Header("Spawn timer")]
    
    [HideInInspector] 
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    
    [Header("Number of Gamebjects in scene")]
    [SerializeField] private int totalObjects;
    public int currentObjects;

    void Update()
    {
        Spawn();
        spawnWait -= 1 * Time.deltaTime;
    }

    void Spawn()
    {
        // Takes and cycles through the random indexes of the items in the array.
        int randimIndex = Random.Range(0, spawnGameObject.Length);

        // Randomises the spawn position with the x/y/z axis also horizontially and vertically.
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-65, 65), 5, Random.Range(-60, 60));

        if (currentObjects < totalObjects && spawnWait <= 0)
        {
            //Random time
            spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
            //Spawn object
            Instantiate(spawnGameObject[randimIndex], randomSpawnPosition, Quaternion.identity);
        }
    }
}
