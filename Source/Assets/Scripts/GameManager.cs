using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Boo.Lang;

public class GameManager : MonoBehaviour {

    public int score;
    public int highscore;
    public float timer = 20f;
    public bool gameStarted;

    private Hud hud;

    private void Awake()
    {
        hud = FindObjectOfType<Hud>();
    }

    private void Start()
    {
        this.UpdateHighscore();
    }

    private void Update()
    {
        if (gameStarted)
        {
            //Minus 1 per second
            timer -= 1 * Time.deltaTime;
            //Without decimal
            hud.SetTimerText(timer.ToString("F0"));

            if(timer <= 0)
            {
                //Game ended

                Bottle[] bottles = FindObjectsOfType<Bottle>();
                foreach(Bottle bottle in bottles)
                {
                    Destroy(bottle.gameObject);
                }

                BottleSpawner[] spawners = FindObjectsOfType<BottleSpawner>();
                foreach (BottleSpawner spawner in spawners)
                {
                    spawner.CancelInvoke();
                }
                gameStarted = false;

                Invoke("RestartGame", 8);
            }
        }
    }

    public void IncreaseScore()
    {
        score++;
        hud.SetScoreText(score);

        if (score > highscore){
            PlayerPrefs.SetInt("Highscore", score);
            this.UpdateHighscore();
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    private void UpdateHighscore()
    {
        highscore = PlayerPrefs.GetInt("Highscore");
        hud.SetHighscoreText(highscore);
    }
}
