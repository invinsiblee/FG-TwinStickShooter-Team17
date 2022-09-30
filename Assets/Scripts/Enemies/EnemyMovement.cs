using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Enemies
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private EnemyStatsSo stats;

        [SerializeField] private GameObject player;

        private void Update()
        {
            transform.LookAt(player.transform);
            Move();
        }

        void Move()
        {
            
        }
    }
}
