using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    private bool done;
    [SerializeField] private float currentTime;
    [SerializeField] private GameObject objectToSpawn;

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        if (!done && currentTime <= 0)
        {
            done = true;
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        }
    }
}
