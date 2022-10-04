using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public bool mortal = true;
    
    [SerializeField] private int maxHealth = 100;
    public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    
    void Update()
    {
        CheckPlayerHealth();
        Death();
    }

    void CheckPlayerHealth()
    {
        //healthBar.SetCurrentHealth(currentHealth);
        
        if (currentHealth <= 0)
        {
            //Dead
            currentHealth = 0;
        }
    }
    private void Death()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (mortal == true && other.CompareTag("GoodBullet") || other.CompareTag("BadBullet"))
        {
            Debug.Log("GotHit");
            TakeDamage(5);
        }

    }
}
