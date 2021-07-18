using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcMovementScript : MonoBehaviour
{

    // first attempts of npc movement
    [SerializeField] private float speed = 1f;
    // Max Values for level bounds of NPCs
    [SerializeField] private float xmin, xmax, ymin, ymax;
    [SerializeField] private float house1xmin, house1xmax, house1ymin, house1ymax;
    [SerializeField] private float house2xmin, house2xmax, house2ymin, house2ymax;
    //[SerializeField] private bool letMeExitHorizontallyPlx = true;
    //[SerializeField] private bool letMeExitVerticallyPlx = true;
    private Vector2 vel;
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
        vel = new Vector2(speed * Random.Range(-1f, 1f), speed * Random.Range(-1f, 1f));
        vel.Normalize();
        rigBod.velocity = vel * speed;
        animations.SetBool("isRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        /* Experimental approach to make houses and other props avoiding areas, glitches with too high velocity though, and the bools intended to not stop the npc from coming back into the area cant prevent it from then moving out the other bounds in the mean time ...
        if ((this.transform.position.x > xmax && letMeExitHorizontallyPlx) || (this.transform.position.y > ymax && letMeExitVerticallyPlx) || (this.transform.position.x < xmin && letMeExitHorizontallyPlx) || (this.transform.position.y < ymin && letMeExitVerticallyPlx))
        {
            vel = new Vector2(0, 0);
            if (rigBod.velocity.x <= 0)
            {
                vel.x = Random.Range(0.3f, 1f);
                letMeExitHorizontallyPlx = false;
            }
            else
            {
                vel.x = Random.Range(-0.3f, -1f);
                letMeExitHorizontallyPlx = false;
            }

            if (rigBod.velocity.y <= 0)
            {
                vel.y = Random.Range(0.3f, 1f);
                letMeExitVerticallyPlx = false;
}
            else
            {
                vel.y = Random.Range(-0.3f, -0.6f);
                letMeExitVerticallyPlx = false;
            }
            vel.Normalize();
            rigBod.velocity = vel * speed;
            animations.SetBool("isRunning", true);
            ResetTimers();
        }

        if (((house1xmin < this.transform.position.x && this.transform.position.x < house1xmax) && letMeExitVerticallyPlx) && ((house1ymin < this.transform.position.y && this.transform.position.y < house1ymax) && letMeExitHorizontallyPlx))
        {
            vel = new Vector2(0, 0);
            if (rigBod.velocity.x <= 0)
            {
                vel.x = Random.Range(0.1f, 1f);
                letMeExitHorizontallyPlx = false;
            }
            else
            {
                vel.x = Random.Range(0.1f, -1f);
                letMeExitHorizontallyPlx = false;
            }

            if (rigBod.velocity.y <= 0)
            {
                vel.y = Random.Range(0.1f, 1f);
                letMeExitVerticallyPlx = false;
            }
            else
            {
                vel.y = Random.Range(0.1f, -0.6f);
                letMeExitVerticallyPlx = false;
            }
            vel.Normalize();
            rigBod.velocity = vel * speed;
            animations.SetBool("isRunning", true);
            ResetTimers();
            letMeExitHorizontallyPlx = false;
        } */

        if(this.transform.position.x > xmax)
        {
            if (TakeARest(0.50f))
            {
                vel = new Vector2(-1, Random.Range(-0.6f, 0.6f));
                vel.Normalize();
                rigBod.velocity = vel * speed;
                animations.SetBool("isRunning", true);
                ResetTimers();
            }
        }
        if (this.transform.position.y > ymax)
        {
            if (TakeARest(0.50f))
            {
                vel = new Vector2(Random.Range(-1f, 1f),Random.Range(-0.6f,0f));
                vel.Normalize();
                rigBod.velocity = vel * speed;
                animations.SetBool("isRunning", true);
                ResetTimers();
            }
        }

        if (this.transform.position.x < xmin)
        {
            if (TakeARest(0.50f))
            {
                vel = new Vector2(1,Random.Range(-0.6f, 0.6f));
                vel.Normalize();
                rigBod.velocity = vel * speed;
                animations.SetBool("isRunning", true);
                ResetTimers();
            }
        }

        if (this.transform.position.y < ymin)
        {
            if (TakeARest(0.50f))
            {
                vel = new Vector2(Random.Range(-1f, 1f), Random.Range(0.6f, 0f));
                vel.Normalize();
                rigBod.velocity = vel * speed;
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
                vel = new Vector2(Random.Range(-0.6f, 0.6f), Random.Range(-0.6f, 0.6f));
                vel.Normalize();
                rigBod.velocity = vel * speed;
                animations.SetBool("isRunning", true);
                ResetTimers();
                //letMeExitHorizontallyPlx = true;
                //letMeExitVerticallyPlx = true;
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
            //letMeExitHorizontallyPlx = true;
            //letMeExitVerticallyPlx = true;
            return false;
        } else
        {
            return true;
        }
    }
}
