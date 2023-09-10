using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text endscore;
    public Text highScore;
    public GameObject gameoverscreen;
    private int gamescore;
    public float scoreincRate = 3;
    private float timer = 0;
    public theFallenScript fallen;


    public void addScore()
    {
        if (!fallen.isplayerdead)
        {
            playerScore = playerScore + 10;
            scoreText.text = playerScore.ToString() + "meters";

            if (gamescore > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", gamescore);
                highScore.text = gamescore.ToString();
            }
        }
       
    }

    public void GameOverScreenActive()
    {
        gameoverscreen.SetActive(true);
        endscore.text = "Distance: " + playerScore + " meters" + "\nSkulls: " + fallen.killscore + "\n Game Score: " + fallen.killscore * playerScore;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


       




    // Start is called before the first frame update
    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        fallen = GameObject.FindGameObjectWithTag("theFallen").GetComponent<theFallenScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < scoreincRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            addScore();
            timer = 0;
        }


        
        gamescore = Mathf.RoundToInt(playerScore * fallen.killscore);
    }
}
