using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RenderPosition : MonoBehaviour
{
    //Used to offset the order in layer based on objects y coordinate 
    [SerializeField] private int sortingOrderOffset = 10000;
    [SerializeField] private bool onlyOnce = false;
    [SerializeField] private bool alsoScaleSprite = false;
    [SerializeField] private float offset = 0;
    private float finalOrder;
    private float scaleFactor = 1f;
    private Renderer myRenderer;


    void Awake()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
    }

    //only update if position changes
    void LateUpdate()
    {
        //sets the specific sorting order in that layer to a common sortingOrderOffset, depending on the where the object is located in the scene (lower y value generally means the object is closer to the camera and is thus rendered first)
        finalOrder = (sortingOrderOffset - (transform.position.y - offset) * 100);
        
        if (alsoScaleSprite)
        {
            //also takes prescaled sprite into consideration; care, this only works as intended on uniform scales, otherwise we need separate scaleFactors for x,y,z
            scaleFactor = (finalOrder / sortingOrderOffset) * this.transform.localScale.x;
            this.gameObject.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
            finalOrder = (sortingOrderOffset - (transform.position.y - offset * scaleFactor) * 100);    //render order also changes depending on the scaleFactor
            myRenderer.sortingOrder = (int)finalOrder;
        } else
        {
            myRenderer.sortingOrder = (int)finalOrder;
        }

        if (onlyOnce)
        {
            Destroy(this);
        }
    }
}
