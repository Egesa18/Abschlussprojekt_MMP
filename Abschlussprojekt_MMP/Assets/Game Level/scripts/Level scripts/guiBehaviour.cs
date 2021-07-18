using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class guiBehaviour : MonoBehaviour
{
    public CursorScript cursor;

    private GameObject timerFront;
    private GameObject vaccine1;
    private GameObject vaccine2;
    private GameObject vaccine3;
    private GameObject scoreObject1;
    private GameObject itemFrame;
    public int selected;
    public int shotsLeftVac1;
    public int shotsLeftVac2;
    public int shotsLeftVac3;
    public int points_score;
    private float counter;
    private float timer;

    public GameObject endScreen;


    private GameObject ammo1;
    private GameObject ammo2;
    private GameObject ammo3;
    private GameObject ammo4;
    private GameObject ammo5;
    private GameObject reload1;
    private GameObject reload2;
    private GameObject reload3;
    private GameObject help;




    // Start is called before the first frame update
    void Start()
    {
        timerFront = GameObject.Find("timerBarFront");
        vaccine1 = GameObject.Find("vaccine1");
        vaccine2 = GameObject.Find("vaccine2");
        vaccine3 = GameObject.Find("vaccine3");
        scoreObject1 = GameObject.Find("points_score");
        itemFrame = GameObject.Find("ItemFrame");
        itemFrame.transform.position = vaccine1.transform.position;
        reload1 = GameObject.Find("reload1");
        reload2 = GameObject.Find("reload2");
        reload3 = GameObject.Find("reload3");
        help = GameObject.Find("Help");
        help.SetActive(false);

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
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            //canvas.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Alpha0))
        {
            //canvas.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            help.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Alpha0))
        {
            help.SetActive(false);
        }

        showShots();
        showReload();
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
            counter = timer / 90.0f;
        }
        else if (counter >= 0.5f)
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
    //changes current selection and moves frame to show
    public void selectVac(int keyNr, Vector3 pos)
    {
        itemFrame.transform.position = pos;
        cursor.selected = keyNr;
    }

    //selects color of current vaccine for # ammo left 
    public void showShots()
    {
        Color color;
        if (cursor.selected == 1)
        {
            color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
            showShotsLeft(color, cursor.shotsLeftVac1);
        }
        else if (cursor.selected == 2)
        {
            color = new Color(239 / 255f, 255 / 255f, 0 / 255f, 255 / 255f);
            showShotsLeft(color, cursor.shotsLeftVac2);
        }
        else if (cursor.selected == 3)
        {
            color = new Color(255 / 255f, 0 / 255f, 3 / 255f, 255 / 255f);
            showShotsLeft(color, cursor.shotsLeftVac3);
        }
    }

    //shows images depending on number of ammo left
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

    //shows bar over vaccine, if vaccine is in reload cooldown
    public void showReload()
    {
        float timer1 = (cursor.reloadTimer1 / 5.0f) * 73.0f;
        reload1.transform.localScale = new Vector2(73.0f, timer1);
        float timer2 = (cursor.reloadTimer2 / 5.0f) * 73.0f;
        reload2.transform.localScale = new Vector2(73.0f, timer2);
        float timer3 = (cursor.reloadTimer3 / 10.0f) * 73.0f;
        reload3.transform.localScale = new Vector2(73.0f, timer3);
    }

}