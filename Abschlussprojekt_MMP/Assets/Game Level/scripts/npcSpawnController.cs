using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcSpawnController : MonoBehaviour
{
    [SerializeField] private List<GameObject> aluhutPrefabs;
    [SerializeField] private float spawnTime = 1.0f;
    float counter = 0.0f;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
    }

    // Update is called once per frame
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

