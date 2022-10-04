using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashCooldown : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    public Image imageCooldown;
    public float cooldown;
    bool isCooldown;


    // Update is called once per frame
    void Update()
    {
        if(playerHealth.mortal == false)
        {
            isCooldown = true;
        }
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
}
