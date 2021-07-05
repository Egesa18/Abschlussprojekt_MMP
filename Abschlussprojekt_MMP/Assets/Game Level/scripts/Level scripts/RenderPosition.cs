using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RenderPosition : MonoBehaviour
{
    //Used to offset the order in layer based on objects y coordinate 
    [SerializeField]
    private int sortingOrderOffset = 10000;
    private Renderer myRenderer;

    void Awake()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
    }

    //only update if position changes
    void LateUpdate()
    {
        //sets the specific sorting order in that layer to a common sortingOrderOffset, depending on the where the object is located in the scene (lower y value generally means the object is closer to the camera and is thus rendered first)
        myRenderer.sortingOrder = (int)(sortingOrderOffset - transform.position.y*10);
    }
}
