using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    AudioSource backgroundmusic;
    public GameObject endScreen;


    public void ExitButton()
    {
      
        Application.Quit();
        Debug.Log("You Exited The Game");
        

    }
public void StartGame()
    {
        
        
        SceneManager.LoadScene("Level1");

        //Cursor.visible = false;

    }

    public void goHome()
    {
      
        SceneManager.LoadScene("Main Menu");
        Debug.Log("loading scene...");
        //Cursor.visible = false;
        endScreen.SetActive(false);
       
    }

}

