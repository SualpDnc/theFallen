using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;

    public float scoreincRate = 3;
    private float timer = 0;

    public void addScore()
    {
        playerScore = playerScore + 5;
        scoreText.text = playerScore.ToString() + "mt";
    }







    // Start is called before the first frame update
    void Start()
    {
        
   
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
    }
}
