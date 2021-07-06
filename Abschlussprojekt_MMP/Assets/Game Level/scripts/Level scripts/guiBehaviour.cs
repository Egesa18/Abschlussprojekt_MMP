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
    public int points_score = 0;
    private int coins;
    private float counter = 0.0f;
    private float timer = 0.0f;

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
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (counter < 0.5f)
        {
            counter = timer / 60.0f;
        } else if (counter >= 0.05f)
        {
            SceneManager.LoadScene("Main Menu");
            Cursor.visible = true;
        }
        timerFront.transform.localScale = new Vector2(counter, 0.5f);
        scoreObject1.GetComponent<Text>().text = "SCORE: " + points_score.ToString();
        scoreObject2.GetComponent<Text>().text = "Type B: " + coins.ToString();
    }
}
