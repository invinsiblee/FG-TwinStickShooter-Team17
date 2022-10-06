using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public float currentHealth;
    [SerializeField] private EnemyStatsSo stats;

    //Manager
    private GameObject manager;
    private RandomSpawner spawnerScript;

    //Sounds
    private AudioSource enemyDeath;
    private AudioSource boxBreak;

    public bool enemy;
    public bool boss;

    public BossHealthBar bossHealthBar;
    public float maxHealth = 750;


    void Start()
    {
        manager = GameObject.Find("GameManager");
        boxBreak = GameObject.Find("BoxBreak").GetComponent<AudioSource>();
        enemyDeath = GameObject.Find("EnemyDeath").GetComponent<AudioSource>();
        spawnerScript = manager.GetComponent<RandomSpawner>();

        currentHealth = stats.health;
        currentHealth = maxHealth;
        bossHealthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        Death();
        CheckBossHealth();
    }

    void CheckBossHealth()
    {
        bossHealthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            //Dead
            currentHealth = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void Death()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            if (enemy)
            {
                //Score.Instance.SetScoreBoss();
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(5);
        }
        if (other.CompareTag("ShotgunProjectile"))
        {
            TakeDamage (50);
        }
    }
}

