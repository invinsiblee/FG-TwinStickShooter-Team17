using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSpawner : MonoBehaviour
{
    public GameObject spawnGameObject;
    
    [Header("Spawn timer")]
    [HideInInspector]
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;

    [Header("Number of Gameobjects in scene")]
    [SerializeField] private int totalObjects;
    public int currentObjects;
    
    [SerializeField] private SpawnerScript spawner;
    
    void Update()
    {
        Spawn();
        spawnWait -= 1 * Time.deltaTime;
    }
    
    void Spawn()
    {
        if (currentObjects < totalObjects && spawnWait <= 0)
        {
            spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
            spawner.Spawn(spawnGameObject);
        }
    }
}
