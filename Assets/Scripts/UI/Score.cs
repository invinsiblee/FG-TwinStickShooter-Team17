using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    int value = 0;

    void Start()
    {
        scoreText.text = value.ToString();
    }
     void Update()
    {
        scoreText.text = value.ToString();

        if (GameObject.FindGameObjectWithTag("Enemy").activeSelf == false)
        {
            scoreText.text = scoreText.text + 10;
        }
    }
}
