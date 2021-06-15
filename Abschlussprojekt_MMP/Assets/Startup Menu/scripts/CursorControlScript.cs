using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControlScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("MouseCursor");
        //nimmt pixel Coordinaten der Maus und transformiert sie in Welt Coords
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //bewegt Cursor zur Maus
        transform.localPosition = new Vector3(mousePos.x, mousePos.y, 1.0f);

        Debug.Log(transform.localPosition);
    }
}
