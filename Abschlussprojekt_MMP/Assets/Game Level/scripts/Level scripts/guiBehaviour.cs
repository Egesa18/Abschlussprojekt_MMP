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
    private GameObject itemFrame;
    private int selected;
    public int shotsLeftVac1;
    public int shotsLeftVac2;
    public int shotsLeftVac3;
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
        itemFrame = GameObject.Find("ItemFrame");
        itemFrame.transform.position = vaccine1.transform.position;
        selected = 1;
        shotsLeftVac1 = 5;
        shotsLeftVac2 = 5;
        shotsLeftVac3 = 5;
        points_score = 0;
        counter = 0.0f;
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        scoreObject1.GetComponent<Text>().text = "SCORE: " + points_score.ToString();
        scoreObject2.GetComponent<Text>().text = "Coins: " + coins.ToString();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Vector3 pos = vaccine1.transform.position;
            selectVac(1, pos);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Vector3 pos = vaccine2.transform.position;
            selectVac(2, pos);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Vector3 pos = vaccine3.transform.position;
            selectVac(3, pos);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            reload();
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (selected == 1)
            {
                shotsLeftVac1--;
            }
            else if (selected == 2)
            {
                shotsLeftVac2--;
            }
            else if (selected == 3)
            {
                shotsLeftVac3--;
            }
            Debug.Log("Shots1 " + shotsLeftVac1 + " Shots2 " + shotsLeftVac2 + " Shots3 " + shotsLeftVac3);
        }
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
            SceneManager.LoadScene("Main Menu");
            Cursor.visible = true;
        }
        timerFront.transform.localScale = new Vector2(counter, 0.5f);
    }

    public void manipulateScore(int pointsIncrement)
    {
        this.points_score += pointsIncrement;
        
    }

    public void selectVac(int keyNr, Vector3 pos)
    {
        itemFrame.transform.position = pos;
        selected = keyNr;
        Debug.Log("Key pressed " + keyNr);
    }


    public void reload()
    {
        if (selected == 1)
        {
            shotsLeftVac1=5;
        }
        else if (selected == 2)
        {
            shotsLeftVac2=5;
        }
        else if (selected == 3)
        {
            shotsLeftVac3=5;
        }
    }
}
