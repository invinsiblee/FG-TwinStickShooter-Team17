using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BossShoot : MonoBehaviour
{
    [SerializeField] Transform[] firingPoint;
    [SerializeField] GameObject[] projectilePrefab;
    //[SerializeField] Animator anim;

    [SerializeField] private EnemyStatsSo stats;

    private float currentFrame;
    private Transform currentPosition;

    private void Update()
    {
        Shoot();
        currentFrame -= 1 * Time.deltaTime;
    }

    private void Shoot()
    {
        if (currentFrame <= 0)
        {
            currentFrame = stats.timeUntilNextShot;
            //anim.SetTrigger("shoot");
            foreach (var t in firingPoint)
            {
                currentPosition = t;
                
                Instantiate(projectilePrefab[Random.Range(0,2)], currentPosition.position, currentPosition.rotation);
            }

            //Instantiate(projectilePrefab, firingPoint[firingPoint.Length].position, Quaternion.identity);
        }
    }
}
