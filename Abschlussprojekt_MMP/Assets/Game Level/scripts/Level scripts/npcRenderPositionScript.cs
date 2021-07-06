using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class npcRenderPositionScript : MonoBehaviour
{
    //Used to offset the order in layer based on objects y coordinate 
    [SerializeField]
    private int sortingOrderOffset = 10000;
    private SortingGroup myRenderer;
    private int prefabOffset = 1;

    void Awake()
    {
        myRenderer = gameObject.GetComponent<SortingGroup>();
    }

    //only update if position changes
    void LateUpdate()
    {
        //sets the specific sorting order in that layer to a common sortingOrderOffset, depending on the where the object is located in the scene (lower y value generally means the object is closer to the camera and is thus rendered first)
        //the offset is needed to accomodate for the relative y position of the prefabs, which would be center otherwise
        myRenderer.sortingOrder = (int)(sortingOrderOffset - (transform.position.y - prefabOffset)*100);
    }
}
