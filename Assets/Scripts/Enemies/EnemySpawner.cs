using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public GameObject ObjectsToSpawn;
    private bool allowSpawn = true;

    [Header("Spawn timer")]
    [SerializeField] private float spawnWait;
    [SerializeField] private float spawnMostWait;

    [Header("Enemies that needs to be killed to win")]
    [SerializeField] private int maxEnemies;
    public int currentDead;
    
    [Header("Number of Gameobjects in scene")]
    [SerializeField] private int totalObjects;
    public int currentObjects;
    [SerializeField] private SpawnerScript spawner;

    public TextMeshProUGUI enemiesLeftText;

    void Update()
    {
        Spawn();
        spawnWait -= 1 * Time.deltaTime;

        //enemies left counter
        enemiesLeftText.text = "Enemies to kill: " + (maxEnemies - currentDead);

        Mathf.Clamp(currentDead, 0f, Mathf.Infinity);
        if (currentDead == maxEnemies)
        {
            allowSpawn = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
