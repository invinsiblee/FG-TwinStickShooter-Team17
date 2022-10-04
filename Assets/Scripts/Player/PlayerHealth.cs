using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [HideInInspector] public bool mortal = true;
    
    [SerializeField] private int maxHealth;
    [HideInInspector] public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    
    void Update()
    {
        CheckPlayerHealth();
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
}
