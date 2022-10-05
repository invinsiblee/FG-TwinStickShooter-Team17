using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ShotgunCooldown : MonoBehaviour
{
    private PlayerControls playerControls;
    public Image imageCooldown;
    public float cooldown;
    bool isCooldown;
    private PlayerInput playerInput;
    private CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
    }
        // Update is called once per frame
        void Update()
    {
        
        if (isCooldown)
        {
            imageCooldown.fillAmount += 1 / cooldown * Time.deltaTime;
        }
        if(imageCooldown.fillAmount >= 1)
        {
            imageCooldown.fillAmount = 0;
            isCooldown = false;
        }
    }
    public void HasShot()
    {
        isCooldown = true;
    }
}
