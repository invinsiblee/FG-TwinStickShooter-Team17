using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHealth : MonoBehaviour
{
    /*
     * Attach this to gameobject
     */
    public float currentHealth;
    [SerializeField] private float maxHealth;

    [SerializeField] private RandomSpawner spawnerScript;
    // Start is called before the first frame update
    void Start()
    {
        spawnerScript = GameObject.FindWithTag("Manager").GetComponent<RandomSpawner>();
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
            spawnerScript.currentObjects -= 1;
            Destroy(gameObject);
        }   
    }
}
