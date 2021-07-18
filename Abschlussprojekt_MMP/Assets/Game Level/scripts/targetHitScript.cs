using UnityEngine;


public class targetHitScript : MonoBehaviour
{
    AudioSource hitSound;
    public guiBehaviour guiScript;
    public CursorScript cursor;
    [SerializeField] private int hitpoints;
    // Start is called before the first frame update
    void Start()
    {
        hitSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int selected = cursor.selected;
            int shotsVac1 = cursor.shotsLeftVac1;
            int shotsVac2 = cursor.shotsLeftVac2;
            int shotsVac3 = cursor.shotsLeftVac3;
            Debug.Log("1:" + selected + ":" + shotsVac1 + ":" + shotsVac2 + ":" + shotsVac3);
            if (selected == 1 && shotsVac1 > 0 || selected == 2 && shotsVac2 > 0 || selected == 3 && shotsVac3 > 0)
            {
                cursor.decreaseShots();
                ShootRay();
            }
 ;

        }
    }

    //Detects hit object
    void ShootRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit)
        {
            if (hit.collider.gameObject.name.Contains("Chara"))
            {
                hitNpc(hit);
            }
            else
            {
                hitObject(hit);
            }
        }
    }

    //handles hit of NPC
    public void hitNpc(RaycastHit2D hit)
    {
        if (hit.collider.gameObject.name.Contains("Chara_12") && cursor.selected == 1 || hit.collider.gameObject.name.Contains("Chara_01") && cursor.selected == 2 || cursor.selected == 3)
        {
            Destroy(hit.collider.gameObject);
            guiScript.manipulateScore(100);
            scoreController.instance.AddScore(100);
            scoreController.instance.updateHighscore();
            hitSound.Play();
        }
        else
        {
            guiScript.manipulateScore(-75);
            scoreController.instance.AddScore(-75);
            scoreController.instance.updateHighscore();
        }

    }

    //handles hit of other objects
    public void hitObject(RaycastHit2D hit)
    {
        Debug.Log("Hit Object");
        guiScript.manipulateScore(-50);
        scoreController.instance.AddScore(-50);
        scoreController.instance.updateHighscore();
    }
}
