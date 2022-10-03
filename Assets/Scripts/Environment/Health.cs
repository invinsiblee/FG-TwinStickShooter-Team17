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
    
    //Manager
    private GameObject manager;
    private RandomSpawner spawnerScript;
    private EnemySpawner enemySpawner;
    
    //Sounds
    private AudioSource enemyDeath;
    private AudioSource boxBreak;
    
    public bool enemy;
    void Start()
    {
        manager = GameObject.Find("GameManager");
        boxBreak = GameObject.Find("BoxBreak").GetComponent<AudioSource>();
        enemyDeath = GameObject.Find("EnemyDeath").GetComponent<AudioSource>();
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
                enemyDeath.Play();
            }
            else
            {
                spawnerScript.currentObjects -= 1; 
                boxBreak.Play();
            }
            Destroy(gameObject);
        }   
    }
}
