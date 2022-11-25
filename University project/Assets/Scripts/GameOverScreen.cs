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
    public GameObject gameOverScreen;
    public void SetUp(int artifactsCollected)
    {
        gameOverScreen.SetActive(true); //showing the game over screen

        //checking if player died or filled inventory
        if (artifactsCollected == 3)
        {
            artifactsText.text = artifactsCollected.ToString() + " ARTIFACT(S) COLLECTED!";
        }
        else if (artifactsCollected == -1)
        {
            gameOverText.text = "GAME OVER";
            artifactsText.text = "YOU DIED AT WORK!";
        }
        else
        {
            gameOverText.text = "INVENTORY FULL";
            artifactsText.text = artifactsCollected.ToString() + " ARTIFACTS COLLECTED!";
        }
    }

    //restarting the game on button click
    public void NewOrderButton()
    {
        SceneManager.LoadScene("Main");
        Time.timeScale = 1;
    }
}
