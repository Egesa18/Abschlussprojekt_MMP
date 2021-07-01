using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowObject : MonoBehaviour
{

    public Transform followObject;



    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(followObject.position.x, followObject.position.y, this.transform.position.z);
    }
}
