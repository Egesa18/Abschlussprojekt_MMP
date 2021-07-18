using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class guiBehaviour : MonoBehaviour
{
    private GameObject timerBack;
    private GameObject timerFront;
    private GameObject vaccine1;
    private GameObject vaccine2;
    private GameObject vaccine3;
    private GameObject scoreObject1;
    private GameObject scoreObject2;
    public GameObject endScreen;
    public scoreController scroreController;



    public int points_score;
    private int coins;
    private float counter;
    private float timer;
   


    // Start is called before the first frame update
    void Start()
    {
        
        timerBack = GameObject.Find("timerBarBack"); 
        timerFront = GameObject.Find("timerBarFront");
        vaccine1 = GameObject.Find("vaccine1");
        vaccine2 = GameObject.Find("vaccine2");
        vaccine3 = GameObject.Find("vaccine3");
        scoreObject1 = GameObject.Find("points_score");
        scoreObject2 = GameObject.Find("coins");
        
        points_score = 0;
       
        //highscore = PlayerPrefs.GetInt("highscore", 0);
        counter = 0.0f;
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        scoreObject1.GetComponent<Text>().text = "SCORE: " + points_score.ToString();
        scoreObject2.GetComponent<Text>().text = "Coins: " + coins.ToString();
       
    }

    void FixedUpdate()
    {
        roundDurationTimer();
    }

    // Controls the Timer Bar indicating round end
    void roundDurationTimer()
    {
        timer += Time.deltaTime;
        if (counter < 0.5f)
        {
            counter = timer / 60.0f;
        } else if (counter >= 0.05f)
        {
            //SceneManager.LoadScene("Scoreboard");
            endScreen.SetActive(true);
           
    




            Cursor.visible = true;
        }
        timerFront.transform.localScale = new Vector2(counter, 0.5f);
    }

    public void manipulateScore(int pointsIncrement)
    {
        this.points_score += pointsIncrement;
      
        //  PlayerPrefs.SetInt("highscore", points_score);

    }
  
}
