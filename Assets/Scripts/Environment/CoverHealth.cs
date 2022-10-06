using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverHealth : MonoBehaviour
{
    public float currentHealth;

    //Manager
    private GameObject manager;
    private RandomSpawner spawnerScript;
    private EnemySpawner enemySpawner;

    private AudioSource boxBreak;

    public bool enemy;
    public bool timer;

    [SerializeField] private float time;

    void Start()
    {
        manager = GameObject.Find("GameManager");
        boxBreak = GameObject.Find("BoxBreak").GetComponent<AudioSource>();
        spawnerScript = manager.GetComponent<RandomSpawner>();


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
        if (currentHealth <= 25)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
        }
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            if (enemy)
            {
                enemySpawner.currentDead += 1;
                Score.Instance.SetScore();
                enemySpawner.currentObjects -= 1;
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
        if (other.CompareTag("BossGoodBullet") || other.CompareTag("BossBadBullet"))
        {
            TakeDamage(1);
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
