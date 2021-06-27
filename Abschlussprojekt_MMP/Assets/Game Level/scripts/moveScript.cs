using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour
{
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        float movementKey = Input.GetAxisRaw("Horizontal");


        //w and s keys included but not currently used for y tracking, maybe later if it makes sense

        if (movementKey == 1) 

        {

            pos.x += speed * Time.deltaTime;

        }

        if (movementKey == -1) 

        {

            pos.x -= speed * Time.deltaTime;

        }



        transform.position = pos;

    }
}
