using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class npcScript : MonoBehaviour
{
    //**
    //[SerializeField] private float speed = 0.2f; 
   // private Vector2 screenBounds;
    private float width, height, xmin, xmax, ymin, ymax;
    Vector3 pos, mousePosition;
    public guiBehaviour guiScript;
    AudioSource bonusSound;

    //private GameObject greenHat2;



    //RectTransform hitBox;

    // Start is called before the first frame update
    void Start()
    {
        bonusSound = GetComponent<AudioSource>();


        //GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
          

            //Debug.Log("Click, shooting ray");
            ShootRay();

        }
    }

    void ShootRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
        if (hit)
        {
            //Debug.Log(hit.collider.gameObject.name);
            Destroy(hit.collider.gameObject);
            guiScript.manipulateScore(100);
            if (guiScript.points_score == 1000)
            {
                bonusSound.Play();
                Debug.Log("You reached Bonus.");
            }
        }
    }
/*
    void detectHit()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        width = hitBox.rect.width;
        height = hitBox.rect.height;
        width = hitBox.transform.localScale.x;
        height = hitBox.transform.localScale.y;
        pos = hitBox.position;
        xmax = pos.x + width;
        xmin = pos.x - width;
        ymax = pos.y + height;
        ymin = pos.y - height;
        if (mousePosition.x < xmax && mousePosition.x > xmin && mousePosition.y < ymax && mousePosition.y > ymin)
            {
                GameObject.Destroy(greenHat2);
                guiScript.manipulateScore(100);
            }
    }
*/
}
