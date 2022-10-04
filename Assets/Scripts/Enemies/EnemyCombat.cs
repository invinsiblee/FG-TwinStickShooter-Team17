using System;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] private EnemyStatsSo stats;
    [SerializeField] private Transform bulletPosition;
    [SerializeField] private GameObject bullet;
    [SerializeField] private AudioSource shoot;

    private float currentFrame;

    private void Start()
    {
        shoot = GameObject.Find("EnemyShoot").GetComponent<AudioSource>();
    }

    private void Update()
    {
        SpawnBullet();
        currentFrame -= 1 * Time.deltaTime;
    }

    void SpawnBullet()
    {
        if (currentFrame <= 0)
        {
            var BulletSpawn = new Vector3(bulletPosition.position.x, bulletPosition.position.y,
                bulletPosition.position.z);
            currentFrame = stats.timeUntilNextShot;
            //instantiate 
            shoot.Play();
            Instantiate(bullet, BulletSpawn, new Quaternion()); 
        }
    }
}
