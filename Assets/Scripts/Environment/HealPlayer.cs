using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        throw new NotImplementedException();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerHealth.currentHealth <= playerHealth.maxHealth)
            {
                playerHealth.currentHealth += 1 * Time.deltaTime;
            }
        }
    }
}
