using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcSpawnController : MonoBehaviour
{
    [SerializeField] private List<GameObject> aluhutPrefabs;
    [SerializeField] private float spawnTime = 1.0f;  // how often do we spawn ( editable in inspector)
    float counter = 0.0f;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    //Calculates the screen bounds into word coordinates

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
    }


    // Update is called once per frame; 
    // Increases the counter every time a new frame is displayed.
    // Every time the spawn time is reached,  it takes a new  random object from the prefabs list and instantiates it as a game object at a random position between the screen bounds.
   
 



    void Update()
    {
        counter += Time.deltaTime;
        if (counter >= spawnTime )
        {
            counter = 0.0f;
            Vector2 spawnPosition = new Vector2(Random.Range(-screenBounds.x, screenBounds.x*1.01f), Random.Range(-screenBounds.y * 0.5f, - screenBounds.y * 0.04f));
            
            GameObject aluhutPerson = Instantiate<GameObject>(aluhutPrefabs[Random.Range(0, aluhutPrefabs.Count)]);
            aluhutPerson.transform.position = spawnPosition;
            //aluhutPerson.hat.GetComponent<SpriteRenderer>().sortingLayerID = SortingLayer.NameToID("Prefabs");
        }

    }
}

