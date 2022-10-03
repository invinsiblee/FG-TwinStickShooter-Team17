using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerDash : MonoBehaviour
    {
        PlayerMovement moveScript;


        public float currentFrame;
        [SerializeField] public float maxFrames;

        [SerializeField] private PlayerHealth playerHealth;

        private PlayerControls playerControls;


        void Start()
        {
          moveScript = GetComponent<PlayerMovement>();   
        }



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
