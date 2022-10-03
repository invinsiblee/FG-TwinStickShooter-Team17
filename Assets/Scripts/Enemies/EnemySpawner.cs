using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] ObjectsToSpawn
        ;
    [Header("Spawn timer")]
    [HideInInspector] 
    [SerializeField] private float spawnWait;
    [SerializeField] private float spawnMostWait;
    [SerializeField] private float spawnLeastWait;
    
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
        int randomIndex = Random.Range(0, ObjectsToSpawn.Length);

        // Randomises the spawn position with the x/y/z axis also horizontially and vertically.
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-85, 85), 5, Random.Range(-87, 87));

        if (currentObjects < totalObjects && spawnWait <= 0)
        {
            //Random time
            spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
            //Spawn object
            Instantiate(ObjectsToSpawn[randomIndex], randomSpawnPosition, Quaternion.identity);
        }
    }
}
