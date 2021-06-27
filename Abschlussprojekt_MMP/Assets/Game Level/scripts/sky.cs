using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sky : MonoBehaviour {

    GameObject cameraview;

    

	// Use this for initialization
	void Start () {
        cameraview = GameObject.Find("CamMovement");
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(cameraview.transform.position.x, 5, 0);

    }
}
