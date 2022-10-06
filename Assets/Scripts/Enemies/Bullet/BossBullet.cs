using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private EnemyStatsSo stats;

    private void Start()
    {
        player = GameObject.Find("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * (stats.bulletSpeed * Time.deltaTime), Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerHealth.mortal && other.CompareTag("Player"))
        {
            Destroy(gameObject);

        }
        else if (CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
