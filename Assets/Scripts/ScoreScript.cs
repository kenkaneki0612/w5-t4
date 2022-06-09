using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ballLeft;
    public CanonShooter shooter;
    public GameObject gameOverPanel;
    public GameObject crosshair;

    private AimToMouse atm;
    public static int scoreValue = 0;

    private void Start()
    {
        atm = GetComponent<AimToMouse>();
    }

    void Update()
    {
        scoreText.text = "Score: " + scoreValue;

        if (shooter.GetBallLeft() > 0)
        {
            ballLeft.text = "Ball: " + shooter.GetBallLeft();
        }
        else
        {
            gameOverPanel.SetActive(true);
            atm.enabled = false;
            crosshair.GetComponent<Crosshair>().enabled = false;
            ballLeft.text = "Nope :))";
        }

        if (scoreValue > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", scoreValue);
        }
    }
}