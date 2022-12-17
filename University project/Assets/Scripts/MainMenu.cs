using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //starts the game
    public void PlayGame()
    {
        SceneManager.LoadScene("Main"); //go to the game
    }

    //closes the app
    public void QuitGame()
    {
        Application.Quit(); //close the app
    }
}
