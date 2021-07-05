using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    Vector3 mp = new Vector3(0f, 0f, 0f);
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 realPosition = new Vector3(mousePosition.x, mousePosition.y, 0.0f);
        rb2d.MovePosition(realPosition);
        bool test = Input.GetMouseButtonDown(0);
        if (test)
        {
            mp = realPosition;
        }
        //print(mp);
    }

}
