using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("You Exited The Game");
    }
public void StartGame()
    {
        SceneManager.LoadScene("Level1");
        scoreController.instance.ResetScore();
    }

}

