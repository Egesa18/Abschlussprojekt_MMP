using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour
{
    [SerializeField] public float horizontalSpeed = 10f;
    [SerializeField] public float verticalSpeed = 2f;
    float horizontalAction, verticalAction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAction = Input.GetAxisRaw("Horizontal");
        verticalAction = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;

        if (horizontalAction == 1)
        {
            if (pos.x < 28)
            {
                pos.x += horizontalSpeed * Time.deltaTime;
            }
        }

        if (horizontalAction == -1)
        {
            if (pos.x > -18)
            {
                pos.x -= horizontalSpeed * Time.deltaTime;
            }
        }

        if (verticalAction == 1)
        {
            if (pos.y < 0)
            {
                pos.y += verticalSpeed * Time.deltaTime;
            }
        }

        if (verticalAction == -1)
        {
            if (pos.y > -1.2)
            {
                pos.y -= verticalSpeed * Time.deltaTime;
            }
        }


        transform.position = pos;
    }
}
