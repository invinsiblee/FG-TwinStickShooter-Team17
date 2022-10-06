using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    [SerializeField] Transform[] firingPoint;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float firingSpeed;
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
                
                Instantiate(projectilePrefab, currentPosition.position, currentPosition.rotation);
                
            }

            //Instantiate(projectilePrefab, firingPoint[firingPoint.Length].position, Quaternion.identity);
        }
    }
}
