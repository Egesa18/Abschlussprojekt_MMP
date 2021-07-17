using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class npcScript : MonoBehaviour
{
    public guiBehaviour guiScript;
    AudioSource bonusSound;
    // Start is called before the first frame update
    void Start()
    {
        bonusSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Click, shooting ray");
            ShootRay();
        }
    }

    void ShootRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
        if (hit)
        {
            //Debug.Log(hit.collider.gameObject.name);
            Destroy(hit.collider.gameObject);
            guiScript.manipulateScore(100);
            if (guiScript.points_score == 1000)
            {
                bonusSound.Play();
                Debug.Log("You reached Bonus.");
            }
        }
    }
}
