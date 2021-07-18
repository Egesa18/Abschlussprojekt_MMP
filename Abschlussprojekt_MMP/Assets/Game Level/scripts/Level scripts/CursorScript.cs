using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{

    public Texture2D crosshair;
    AudioSource shootingSound;
    public GameObject endscreen;

    public int selected;
    public int shotsLeftVac1;
    public int shotsLeftVac2;
    public int shotsLeftVac3;
    public float reloadTimer1;
    public float reloadTimer2;
    public float reloadTimer3;


    // Start is called before the first frame update
    void Start()
    {
        shootingSound = GetComponent<AudioSource>();
        Vector2 cursorOffset = new Vector2(crosshair.width/2 , crosshair.height/2);
        Cursor.SetCursor(crosshair, cursorOffset, CursorMode.Auto);
        selected = 1;
        shotsLeftVac1 = 5;
        shotsLeftVac2 = 5;
        shotsLeftVac3 = 5;
        reloadTimer1 = 0.0f;
        reloadTimer2 = 0.0f;
        reloadTimer3 = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (endscreen.activeSelf == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (selected == 1 && shotsLeftVac1 > 0 || selected == 2 && shotsLeftVac2 > 0 || selected == 3 && shotsLeftVac3 > 0)
                {
                    shootingSound.Play();
                }


                //Debug.Log("Click, shooting ray");


            }
        }
        reloadTiming();
        if (Input.GetKeyDown(KeyCode.R))
        {
            reload();
        }

    }

    //calculates reload cooldown left
    public void reloadTiming()
    {
        if (reloadTimer1 > 0)
        {
            reloadTimer1 -= Time.deltaTime;
        }
        if (reloadTimer2 > 0)
        {
            reloadTimer2 -= Time.deltaTime;
        }
        if (reloadTimer3 > 0)
        {
            reloadTimer3 -= Time.deltaTime;
        }
    }

    //reloads ammo if not in cooldown
    public void reload()
    {
        if (selected == 1)
        {
            if (reloadTimer1 <= 0.0f)
            {
                shotsLeftVac1 = 5;
                reloadTimer1 = 5.0f;
            }
            else
            {
                Debug.Log("1: Zu früh" + reloadTimer1);
            }

        }
        else if (selected == 2)
        {
            if (reloadTimer2 <= 0.0f)
            {
                shotsLeftVac2 = 5;
                reloadTimer2 = 5.0f;
            }
            else
            {
                Debug.Log("2: Zu früh");
            }
        }
        else if (selected == 3)
        {
            if (reloadTimer3 <= 0.0f)
            {
                shotsLeftVac3 = 5;
                reloadTimer3 = 10.0f;
            }
            else
            {
                Debug.Log("3: Zu früh");
            }
        }
    }

    //decreases current vaccine by 1 ammo when shooting
    public void decreaseShots()
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
    }

}
