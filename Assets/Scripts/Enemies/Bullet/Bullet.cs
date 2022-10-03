using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemies;
public class Bullet : MonoBehaviour
{
    [SerializeField] private EnemyStatsSo stats;
    private bool enemyBullet;
    private Transform player;
    private Vector3 playerPos;

    private Vector3 direction;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        playerPos = player.position;
        direction = (playerPos - transform.position).normalized;
    }

    private void Update()
    {
        //var step =  stats.bulletSpeed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, playerPos, step);

        transform.position += direction * stats.bulletSpeed * Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (enemyBullet && other.CompareTag("Player"))
        {
            Destroy(gameObject);
            
        }
        else if (!enemyBullet && CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
