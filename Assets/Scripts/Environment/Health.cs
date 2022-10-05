using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    public bool timer;

    [SerializeField] private float time;
    
    void Start()
    {
        manager = GameObject.Find("GameManager");
        boxBreak = GameObject.Find("BoxBreak").GetComponent<AudioSource>();
        enemyDeath = GameObject.Find("EnemyDeath").GetComponent<AudioSource>();
        spawnerScript = manager.GetComponent<RandomSpawner>();
        enemySpawner = manager.GetComponent<EnemySpawner>();
        
        currentHealth = stats.health;
        if (enemy)
        {
            enemySpawner.currentObjects += 1;
        }
        else
        {
            spawnerScript.currentObjects += 1;
        }
    }
    
    void Update()
    {
        Death();
        DeathTimer();
    }

    private void Death()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            if (enemy)
            {
                enemySpawner.currentDead += 1;
                Score.Instance.SetScore();
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
    
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "ShotgunProjectile")
        {
            TakeDamage(50);
        }
    }

    void DeathTimer()
    {
        if (timer)
        {
            time -= 1 * Time.deltaTime;
            if (time <= 0)
            {
                currentHealth = 0;
            }
        }
    }
}
