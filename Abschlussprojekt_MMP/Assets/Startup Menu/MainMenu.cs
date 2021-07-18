using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    // private GameObject backgroundsound;
    public GameObject backgroundmusic;
    public void ExitButton()
    {
      
        Application.Quit();
        Debug.Log("You Exited The Game");
        backgroundmusic.GetComponent<AudioSource>().Stop();        

    }
public void StartGame()
    {
        SceneManager.LoadScene("Level1");
        //Cursor.visible = false;
    }

}

