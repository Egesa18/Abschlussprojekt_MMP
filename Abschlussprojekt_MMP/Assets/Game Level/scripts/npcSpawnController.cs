using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcSpawnController : MonoBehaviour
{
    [SerializeField] private List<GameObject> aluhutPrefabs;
    [SerializeField] private float spawnTime;  // how often do we spawn ( editable in inspector)
    float counter = 0.0f;

    //private Vector2 screenBounds;
    [SerializeField] private float xmin, xmax, ymin, ymax;

    AudioSource spawningSound;

    // Start is called before the first frame update
    //Calculates the screen bounds into word coordinates

    void Start()
    {
        spawningSound = GetComponent<AudioSource>();
        //Why don't we just manually define the spawning area
        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));

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
            spawnTime = Random.Range(0.5f,3f);
            
            Vector2 spawnPosition = new Vector2(Random.Range(xmin, xmax), Random.Range(ymin, ymax));
            GameObject aluhutPerson = Instantiate<GameObject>(aluhutPrefabs[Random.Range(0, aluhutPrefabs.Count)]);
            aluhutPerson.transform.position = spawnPosition;
            spawningSound.Play();

            /* Why would we need this? 
            if (aluhutPerson.transform.position.x > 0.0f && aluhutPerson.transform.position.x < screenBounds.x)
            {
                spawningSound.Play();
               // Debug.Log(aluhutPerson.transform.position.x);
            }
            */
        }

    }
}

