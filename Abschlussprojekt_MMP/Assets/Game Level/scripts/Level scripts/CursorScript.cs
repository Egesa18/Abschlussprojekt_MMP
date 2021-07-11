using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{

    public Texture2D crosshair;
    AudioSource shootingSound;

    // Start is called before the first frame update
    void Start()
    {
        shootingSound = GetComponent<AudioSource>();
        Vector2 cursorOffset = new Vector2(crosshair.width/2 , crosshair.height/2);
        Cursor.SetCursor(crosshair, cursorOffset, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootingSound.Play();

            //Debug.Log("Click, shooting ray");
           

        }
    }
}
