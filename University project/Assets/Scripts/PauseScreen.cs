using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    //other game objects
    public GameObject pauseScreen; 
    public GameObject audioPlayer;

    public static bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        //initially the game is going
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //check if the game is currently paused
            if (isPaused)
            {
                ResumeGame(); //resumes
            }
            else
            {
                PauseGame(); //pause
            }
        }
    }

    //resumes the game
    public void ResumeGame()
    {
        audioPlayer.GetComponent<AudioSource>().UnPause(); //unpause music
        isPaused = false; //change flag
        Time.timeScale = 1f; //unfreeze time
        pauseScreen.gameObject.SetActive(false); //remove puase screen
    }

    //pauses the game
    public void PauseGame()
    {
        audioPlayer.GetComponent<AudioSource>().Pause(); //pause music
        isPaused = true; //change flag
        Time.timeScale = 0f; //freeze time
        pauseScreen.gameObject.SetActive(true); //show pause screen
    }

    //wuits to main menu
    public void QuitToMenu()
    {
        Time.timeScale = 1f; //unfreeze time
        SceneManager.LoadScene("Menu"); //go to main menu
    }
}
