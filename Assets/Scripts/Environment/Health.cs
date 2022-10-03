using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

public class Health : MonoBehaviour
{
    /*
     * Attach this to gameobject
     */
    public float currentHealth;
    [SerializeField] private EnemyStatsSo stats;
    private GameObject manager;
    private RandomSpawner spawnerScript;
    private EnemySpawner enemySpawner;

    public bool enemy;
    void Start()
    {
        manager = GameObject.Find("GameManager");
        spawnerScript = manager.GetComponent<RandomSpawner>();
        enemySpawner = manager.GetComponent<EnemySpawner>();
        currentHealth = stats.health;
        spawnerScript.currentObjects += 1;
    }

    // Update is called once per frame
    void Update()
    {
        Death();
    }

    private void Death()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            if (enemy)
            {
                enemySpawner.currentObjects -= 1;
            }
            else
            {
                spawnerScript.currentObjects -= 1; 
            }
            Destroy(gameObject);
        }   
    }
}
