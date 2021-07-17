using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcMovementScript : MonoBehaviour
{

    // first attempts of npc movement
    [SerializeField] private float speed = 1f;
    // Max Values for level bounds of NPCs
    [SerializeField] private float xmin, xmax, ymin, ymax;
    private Rigidbody2D rigBod;
    private Animator animations;
    private float passedTime;
    private float switchTime;

    // Start is called before the first frame update
    void Start()
    {
        rigBod = GetComponent<Rigidbody2D>();
        animations = GetComponent<Animator>();
        switchTime = Random.Range(1f, 4f);

        //I think it's better when the NPCs move frome the getgo ond only have a chance to stand for a moment later
        rigBod.velocity = new Vector2(speed * Random.Range(-1f, 1f), speed * Random.Range(-1f, 1f)); 
        animations.SetBool("isRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        // This section is designed to not let the NPC escape the playing area
        // Once the NPC moved too far towards the level bounds (defined in xmin/max, ymin/max)
        // It is forced to move back towards the playing area ... I plan to only limit this on solid objects
        // like the top buildings, so some NPCs may actually escape bottom/left/right to make it harder for the player
        if(this.transform.position.x > xmax)
        {
            if (TakeARest(0.50f))
            {
                rigBod.velocity = new Vector2(speed * -1, speed * Random.Range(-0.6f, 0.6f));
                animations.SetBool("isRunning", true);
                ResetTimers();
            }
        }
        if (this.transform.position.y > ymax)
        {
            if (TakeARest(0.50f))
            {
                rigBod.velocity = new Vector2(speed * Random.Range(-1f, 1f), speed * Random.Range(-0.6f,0f));
                animations.SetBool("isRunning", true);
                ResetTimers();
            }
        }

        if (this.transform.position.x < xmin)
        {
            if (TakeARest(0.50f))
            {
                rigBod.velocity = new Vector2(speed * 1, speed * Random.Range(-0.6f, 0.6f));
                animations.SetBool("isRunning", true);
                ResetTimers();
            }
        }

        if (this.transform.position.y < ymin)
        {
            if (TakeARest(0.50f))
            {
                rigBod.velocity = new Vector2(speed * Random.Range(-1f, 1f), speed * Random.Range(0.6f, 0f));
                animations.SetBool("isRunning", true);
                ResetTimers();
            }
        }

        // Here, after the randomly set time the NPC can change his behaviour
        // He can either go into IDLE mode (~33% chance), or move into a random direction
        // at random speed (0 <-> speed)
        passedTime += Time.deltaTime;
        if (passedTime > switchTime)
        {
            if(TakeARest(0.50f)){
                rigBod.velocity = new Vector2(speed * Random.Range(-0.6f, 0.6f), speed * Random.Range(-0.6f, 0.6f));
                animations.SetBool("isRunning", true);
                ResetTimers();
            }
        }

    }

    void ResetTimers()
    {
        this.passedTime = 0f;
        this.switchTime = Random.Range(1f, 4f);
    }

    bool TakeARest(float chance)
    {
        if (Random.value < chance)
        {
            rigBod.velocity = new Vector2(0, 0);
            animations.SetBool("isRunning", false);
            ResetTimers();
            return false;
        } else
        {
            return true;
        }
    }
}
