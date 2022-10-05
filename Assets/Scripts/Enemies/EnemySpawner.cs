using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private bool allowSpawn = true;
    [SerializeField] private int maxEnemies;
    public int currentDead;
    
    public GameObject ObjectsToSpawn;
    
    [Header("Spawn timer")]
    [SerializeField] private float spawnWait;
    [SerializeField] private float spawnMostWait;

    [Header("Number of Gamebjects in scene")]
    [SerializeField] private int totalObjects;
    public int currentObjects;
    [SerializeField] private SpawnerScript spawner;

    void Update()
    {
        Spawn();
        spawnWait -= 1 * Time.deltaTime;
        
        if (currentDead == maxEnemies)
        {
            allowSpawn = false;
            //Load next level?
        }
    }

    void Spawn()
    {
        if (allowSpawn && currentObjects <= totalObjects && spawnWait <= 0)
        {
            spawnWait = spawnMostWait;
            spawner.Spawn(ObjectsToSpawn);
        }
    }
}
