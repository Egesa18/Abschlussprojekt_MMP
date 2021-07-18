using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreController : MonoBehaviour
{

    public Text scoreboard_highscore_text;
    public Text scoreboard_score_text;
    public int score, highscore;
    public static scoreController instance;
    // Start is called before the first frame update
    void Start()
    {

    }


    public void Awake()
    {

        instance = this;
        if (PlayerPrefs.HasKey("highScore"))
        {
            highscore = PlayerPrefs.GetInt("highScore");
            scoreboard_highscore_text.text = highscore.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore(int increment)
    {
        score += increment;
        updateHighscore();
        scoreboard_score_text.text = score.ToString();





    }

    public void updateHighscore()
    {
        if (score > highscore)
        {
            highscore = score;
            scoreboard_highscore_text.text = highscore.ToString();
            Debug.Log(scoreboard_highscore_text.text);
            PlayerPrefs.SetInt("highScore", highscore);

        }

    }
    public void ResetScore()
    {
        score = 0;
        scoreboard_score_text.text = score.ToString();
        scoreboard_highscore_text.text = highscore.ToString();

    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("highScore");
        highscore = 0;
        scoreboard_highscore_text.text = highscore.ToString();
    }
}
