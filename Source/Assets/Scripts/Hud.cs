using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public Text timerText;
    public Text scoreText;
    public Text highscoreText;

    public void SetScoreText(int value)
    {
        scoreText.text = "Treffer: " + value;
    }

    public void SetHighscoreText(int value)
    {
        highscoreText.text = "Highscore: " + value;
    }

    public void SetTimerText(string value)
    {
        timerText.text = value + " Sekunden";
    }
}
