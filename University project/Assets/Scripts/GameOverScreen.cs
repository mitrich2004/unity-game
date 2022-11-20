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
        if (artifactsCollected >= 0)
        {
            artifactsText.text = artifactsCollected.ToString() + " ARTIFACTS COLLECTED!";
        }
        else
        {
            gameOverText.text = "GAME OVER";
            artifactsText.text = "YOU DIED AT WORK!";
        }
    }

    //restarting the game on button click
    public void NewOrderButton()
    {
        SceneManager.LoadScene("Main");
        Time.timeScale = 1;
    }
}
