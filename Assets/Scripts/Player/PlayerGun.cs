using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] Transform firingPoint;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float firingSpeed;
    [SerializeField] Animator anim;
    public static PlayerGun Instance;

    private float lastTimeShot = 0;

    void Awake()
    {
        Instance = GetComponent<PlayerGun>();
    }

    public void Shoot()
    {
        if (lastTimeShot + firingSpeed < Time.time)
        {
            anim.SetTrigger("shoot");
            lastTimeShot = Time.time;
            Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
        }
    }
}
