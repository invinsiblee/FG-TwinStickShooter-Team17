using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private GameObject deathAnimation;
    private Scene scene;
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
        scene = SceneManager.GetActiveScene();
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
        ScoreCount();
    }

    private void Death()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            if (enemy)
            {
                Instantiate(deathAnimation, transform.position, Quaternion.identity);
                enemySpawner.currentDead += 1;
                //Score.Instance.SetScore();
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
    void ScoreCount()
    {
        if (currentHealth <= 0 && scene.name == "Arcade")
        {
            Death();
            Score.Instance.SetScore();
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
