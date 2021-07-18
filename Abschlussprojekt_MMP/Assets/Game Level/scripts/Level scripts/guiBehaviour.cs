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

    public GameObject endScreen;
    

    private GameObject ammo1;
    private GameObject ammo2;
    private GameObject ammo3;
    private GameObject ammo4;
    private GameObject ammo5;



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

        ammo1 = GameObject.Find("ammo1");
        ammo2 = GameObject.Find("ammo2");
        ammo3 = GameObject.Find("ammo3");
        ammo4 = GameObject.Find("ammo4");
        ammo5 = GameObject.Find("ammo5");
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
            //SceneManager.LoadScene("Main Menu");
            endScreen.SetActive(true);

            //GameObject ThemeSound = GameObject.FindGameObjectWithTag("Player");
          //  Destroy(ThemeSound);
            
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
        Color color;
        if (selected == 1)
        {
            color = new Color(255/255f, 255/255f, 255/255f, 255/255f);
            showShotsLeft(color, shotsLeftVac1);
        }
        else if (selected == 2)
        {
            color = new Color(239/255f, 255/255f, 0/255f, 255/255f);
            showShotsLeft(color, shotsLeftVac2);
        }
        else if (selected == 3)
        {
            color = new Color(255/255f, 0/255f, 3/255f, 255/255f);
            showShotsLeft(color, shotsLeftVac3);
        }
    }

    public void showShotsLeft(Color color, int shots)
    {
        ammo1.GetComponent<Image>().color = color;
        ammo2.GetComponent<Image>().color = color;
        ammo3.GetComponent<Image>().color = color;
        ammo4.GetComponent<Image>().color = color;
        ammo5.GetComponent<Image>().color = color;
        if (shots == 5)
        {
            ammo1.SetActive(true);
            ammo2.SetActive(true);
            ammo3.SetActive(true);
            ammo4.SetActive(true);
            ammo5.SetActive(true);
        }
        else if (shots == 4)
        {
            ammo1.SetActive(true);
            ammo2.SetActive(true);
            ammo3.SetActive(true);
            ammo4.SetActive(true);
            ammo5.SetActive(false);
        }
        else if (shots == 3)
        {
            ammo1.SetActive(true);
            ammo2.SetActive(true);
            ammo3.SetActive(true);
            ammo4.SetActive(false);
            ammo5.SetActive(false);
        }
        else if (shots == 2)
        {
            ammo1.SetActive(true);
            ammo2.SetActive(true);
            ammo3.SetActive(false);
            ammo4.SetActive(false);
            ammo5.SetActive(false);
        }
        else if (shots == 1)
        {
            ammo1.SetActive(true);
            ammo2.SetActive(false);
            ammo3.SetActive(false);
            ammo4.SetActive(false);
            ammo5.SetActive(false);
        }
        else if (shots == 0)
        {
            ammo1.SetActive(false);
            ammo2.SetActive(false);
            ammo3.SetActive(false);
            ammo4.SetActive(false);
            ammo5.SetActive(false);
        }
    }

}
