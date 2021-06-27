using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class backgroundScript : MonoBehaviour
{
    private GameObject healthBack;
    private GameObject healthFront;
    private GameObject syringe1;
    private GameObject syringe2;
    private GameObject syringe3;
    private GameObject scoreObject1;
    private int score1;
    private GameObject scoreObject2;
    private int score2;
    private GameObject scoreObject3;
    private int score3;
    private float counter = 0.0f;
    private float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        healthBack = GameObject.Find("healthBarBack"); 
        healthFront = GameObject.Find("healthBarFront");
        syringe1 = GameObject.Find("syringe1");
        syringe2 = GameObject.Find("syringe2");
        syringe3 = GameObject.Find("syringe3");
        scoreObject1 = GameObject.Find("score1");
        scoreObject2 = GameObject.Find("score2");
        scoreObject3 = GameObject.Find("score3");
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
        healthFront.transform.localScale = new Vector2(counter, 0.5f);
        scoreObject1.GetComponent<Text>().text = "Type A: " + score1.ToString();
        scoreObject2.GetComponent<Text>().text = "Type B: " + score2.ToString();
        scoreObject3.GetComponent<Text>().text = "Type C: " + score3.ToString();
    }
}
