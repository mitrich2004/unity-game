using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen: MonoBehaviour
{
    //UI references
    public Text artifactsText;
    public Text gameOverText;

    //other game objects
    public GameObject gameOverScreen;
    public GameObject house;
    public GameObject audioPlayer;

    //game over flag
    public bool gameOver;

    //creates the house
    public void SetUp()
    {
        //order completed or inventory full
        gameOver = true;
        Instantiate(house);
    }

    //shows final screen
    public void showGameOverScreen(int artifactsCollected)
    {
        audioPlayer.GetComponent<AudioSource>().Stop();
        Time.timeScale = 0; //stops time
        gameOverScreen.SetActive(true); //showing the game over screen

        //checking if player died or filled inventory
        if (artifactsCollected == 3)
        {
            //order completed
            artifactsText.text = artifactsCollected.ToString() + " ARTIFACT(S) COLLECTED!";
        }
        else if (artifactsCollected == -1)
        {
            //no lives left
            gameOverText.text = "GAME OVER!";
            artifactsText.text = "YOU DIED AT WORK!";
        }
        else
        {
            //inventory full
            gameOverText.text = "ORDER DELIVERED!";
            artifactsText.text = artifactsCollected.ToString() + " ARTIFACT(S) COLLECTED!";
        }
    }

    //restarting the game on button click
    public void NewOrderButton()
    {
        SceneManager.LoadScene("Main"); //reloading scene
        Time.timeScale = 1; //resuming time
    }
}
