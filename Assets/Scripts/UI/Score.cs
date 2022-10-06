using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score Instance;
    public TextMeshProUGUI scoreText;
    int value = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        scoreText.text = value.ToString();
    }
     public void SetScore()
    {
        value += 10;
        scoreText.text = value.ToString();
    }
    public void SetScoreBoss()
    {
        value += 100;
        scoreText.text = value.ToString();
    }
}
