using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcScript : MonoBehaviour
{
    //**
    [SerializeField] private float speed = 0.2f; 
   // private Vector2 screenBounds;

    float width;
    float height;
    float xmin;
    float xmax;
    float ymin;
    float ymax;
    Vector3 pos;
    Vector3 mousePosition;
    public backgroundScript bgS;

    private GameObject greenHat2;
    
    RectTransform hitBox;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0.0f);

        greenHat2 = GameObject.Find("greenHat2");
        hitBox = (RectTransform)greenHat2.transform;
        
    }

    // Update is called once per frame
    void Update()
    {

        //todo: destroy the npcs after a while

        if (Input.GetMouseButtonDown(0))
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
                bgS.score1 += 100;
            }

 
        }
        print(width + " " + height);
        print(pos);
        print("Mouse:" + mousePosition);
    }
}
