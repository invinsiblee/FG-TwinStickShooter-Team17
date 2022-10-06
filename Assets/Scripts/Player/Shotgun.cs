using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    [SerializeField] Transform firingPoint;
    [SerializeField] GameObject shotgunProjectilePrefab;
    [SerializeField] float firingSpeed;
    [SerializeField] ShotgunCooldown coolDownScript;
    private AudioSource shotgun;

    public static Shotgun Instance;

    private float lastTimeShot = 0;

    void Awake()
    {
        Instance = GetComponent<Shotgun>();
        shotgun = GameObject.Find("ShotgunSound").GetComponent<AudioSource>();
    }

    public void ShotgunShoot()
    {
        if (lastTimeShot + firingSpeed < Time.time)
        {
            shotgun.Play();
            lastTimeShot = Time.time;
            Instantiate(shotgunProjectilePrefab, firingPoint.position, firingPoint.rotation);
            coolDownScript.HasShot();
        }

    }
}
