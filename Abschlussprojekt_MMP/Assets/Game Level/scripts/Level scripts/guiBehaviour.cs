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
    public int selected;
    public int shotsLeftVac1;
    public int shotsLeftVac2;
    public int shotsLeftVac3;
    public int points_score;
    private int coins;
    private float counter;
    private float timer;


    private GameObject vac1s1;
    private GameObject vac1s2;
    private GameObject vac1s3;
    private GameObject vac1s4;
    private GameObject vac1s5;
    private GameObject vac2s1;
    private GameObject vac2s2;
    private GameObject vac2s3;
    private GameObject vac2s4;
    private GameObject vac2s5;
    private GameObject vac3s1;
    private GameObject vac3s2;
    private GameObject vac3s3;
    private GameObject vac3s4;
    private GameObject vac3s5;



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


        vac1s1 = GameObject.Find("vac1s1");
        vac1s2 = GameObject.Find("vac1s2");
        vac1s3 = GameObject.Find("vac1s3");
        vac1s4 = GameObject.Find("vac1s4");
        vac1s5 = GameObject.Find("vac1s5");
        vac2s1 = GameObject.Find("vac2s1");
        vac2s2 = GameObject.Find("vac2s2");
        vac2s3 = GameObject.Find("vac2s3");
        vac2s4 = GameObject.Find("vac2s4");
        vac2s5 = GameObject.Find("vac2s5");
        vac3s1 = GameObject.Find("vac3s1");
        vac3s2 = GameObject.Find("vac3s2");
        vac3s3 = GameObject.Find("vac3s3");
        vac3s4 = GameObject.Find("vac3s4");
        vac3s5 = GameObject.Find("vac3s5");

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
            if (selected == 1 && shotsLeftVac1 > 0)
            {
                shotsLeftVac1--;
            }
            else if (selected == 2 && shotsLeftVac2 > 0)
            {
                shotsLeftVac2--;
            }
            else if (selected == 3 && shotsLeftVac3 > 0)
            {
                shotsLeftVac3--;
            }
            Debug.Log("Shots1 " + shotsLeftVac1 + " Shots2 " + shotsLeftVac2 + " Shots3 " + shotsLeftVac3);
        }
        showShots();
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

    public void showShots()
    {
        if (selected == 1)
        {
            hideVac2();
            hideVac3();
            showShotsLeft1();
        }
        else if (selected == 2)
        {
            hideVac1();
            hideVac3();
            showShotsLeft2();
        }
        else if (selected == 3)
        {
            hideVac1();
            hideVac2();
            showShotsLeft3();
        }
    }




    public void showShotsLeft1()
    {
        if (shotsLeftVac1 == 5)
        {
            vac1s1.SetActive(true);
            vac1s2.SetActive(true);
            vac1s3.SetActive(true);
            vac1s4.SetActive(true);
            vac1s5.SetActive(true);
        }
        else if (shotsLeftVac1 == 4)
        {
            vac1s1.SetActive(true);
            vac1s2.SetActive(true);
            vac1s3.SetActive(true);
            vac1s4.SetActive(true);
            vac1s5.SetActive(false);
        }
        else if (shotsLeftVac1 == 3)
        {
            vac1s1.SetActive(true);
            vac1s2.SetActive(true);
            vac1s3.SetActive(true);
            vac1s4.SetActive(false);
            vac1s5.SetActive(false);
        }
        else if (shotsLeftVac1 == 2)
        {
            vac1s1.SetActive(true);
            vac1s2.SetActive(true);
            vac1s3.SetActive(false);
            vac1s4.SetActive(false);
            vac1s5.SetActive(false);
        }
        else if (shotsLeftVac1 == 1)
        {
            vac1s1.SetActive(true);
            vac1s2.SetActive(false);
            vac1s3.SetActive(false);
            vac1s4.SetActive(false);
            vac1s5.SetActive(false);
        }
        else if (shotsLeftVac1 == 0)
        {
            vac1s1.SetActive(false);
            vac1s2.SetActive(false);
            vac1s3.SetActive(false);
            vac1s4.SetActive(false);
            vac1s5.SetActive(false);
        }
    }

    public void showShotsLeft2()
    {
        if (shotsLeftVac2 == 5)
        {
            vac2s1.SetActive(true);
            vac2s2.SetActive(true);
            vac2s3.SetActive(true);
            vac2s4.SetActive(true);
            vac2s5.SetActive(true);
        }
        else if (shotsLeftVac2 == 4)
        {
            vac2s1.SetActive(true);
            vac2s2.SetActive(true);
            vac2s3.SetActive(true);
            vac2s4.SetActive(true);
            vac2s5.SetActive(false);
        }
        else if (shotsLeftVac2 == 3)
        {
            vac2s1.SetActive(true);
            vac2s2.SetActive(true);
            vac2s3.SetActive(true);
            vac2s4.SetActive(false);
            vac2s5.SetActive(false);
        }
        else if (shotsLeftVac1 == 2)
        {
            vac1s1.SetActive(true);
            vac1s2.SetActive(true);
            vac1s3.SetActive(false);
            vac1s4.SetActive(false);
            vac1s5.SetActive(false);
        }
        else if (shotsLeftVac2 == 1)
        {
            vac2s1.SetActive(true);
            vac2s2.SetActive(false);
            vac2s3.SetActive(false);
            vac2s4.SetActive(false);
            vac2s5.SetActive(false);
        }
        else if (shotsLeftVac2 == 0)
        {
            vac2s1.SetActive(false);
            vac2s2.SetActive(false);
            vac2s3.SetActive(false);
            vac2s4.SetActive(false);
            vac2s5.SetActive(false);
        }
    }

    public void showShotsLeft3()
    {
        if (shotsLeftVac3 == 5)
        {
            vac3s1.SetActive(true);
            vac3s2.SetActive(true);
            vac3s3.SetActive(true);
            vac3s4.SetActive(true);
            vac3s5.SetActive(true);
        }
        else if (shotsLeftVac3 == 4)
        {
            vac3s1.SetActive(true);
            vac3s2.SetActive(true);
            vac3s3.SetActive(true);
            vac3s4.SetActive(true);
            vac3s5.SetActive(false);
        }
        else if (shotsLeftVac3 == 3)
        {
            vac3s1.SetActive(true);
            vac3s2.SetActive(true);
            vac3s3.SetActive(true);
            vac3s4.SetActive(false);
            vac3s5.SetActive(false);
        }
        else if (shotsLeftVac3 == 2)
        {
            vac3s1.SetActive(true);
            vac3s2.SetActive(true);
            vac3s3.SetActive(false);
            vac3s4.SetActive(false);
            vac3s5.SetActive(false);
        }
        else if (shotsLeftVac3 == 1)
        { 
            vac3s1.SetActive(true);
            vac3s2.SetActive(false);
            vac3s3.SetActive(false);
            vac3s4.SetActive(false);
            vac3s5.SetActive(false);
        }
        else if (shotsLeftVac3 == 0)
        {
            vac3s1.SetActive(false);
            vac3s2.SetActive(false);
            vac3s3.SetActive(false);
            vac3s4.SetActive(false);
            vac3s5.SetActive(false);
        }
    }

    public void hideVac1()
    {
        vac1s1.SetActive(false);
        vac1s2.SetActive(false);
        vac1s3.SetActive(false);
        vac1s4.SetActive(false);
        vac1s5.SetActive(false);
    }

    public void hideVac2()
    {
        vac2s1.SetActive(false);
        vac2s2.SetActive(false);
        vac2s3.SetActive(false);
        vac2s4.SetActive(false);
        vac2s5.SetActive(false);
    }

    public void hideVac3()
    {
        vac3s1.SetActive(false);
        vac3s2.SetActive(false);
        vac3s3.SetActive(false);
        vac3s4.SetActive(false);
        vac3s5.SetActive(false);
    }
}
