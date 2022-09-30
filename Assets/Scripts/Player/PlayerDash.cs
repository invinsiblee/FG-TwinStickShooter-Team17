using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerDash : MonoBehaviour
    {
        public float currentFrame;
        [SerializeField] public float maxFrames;

        [SerializeField] private PlayerHealth playerHealth;
        
        
        public void Dash()
        {
            currentFrame = maxFrames;
            playerHealth.mortal = false;

            if (currentFrame <= 0)
            {
                currentFrame = 0;
                playerHealth.mortal = true;
            }
        }
    }
}
