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
    public Image wizardImage;
    public Image speachBubbleImage;
    public Text wizardText;

    //other game objects
    public GameObject gameOverScreen;
    public GameObject house;
    public GameObject audioPlayer;

    //game over flag
    public bool gameOver;

    //wizards sprites
    public Sprite purpleWizard;
    public Sprite blueWizard;
    public Sprite brownWizard;

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
            wizardImage.enabled = false;
            speachBubbleImage.enabled = false;
            wizardText.enabled = false;
        }
        else
        {
            //inventory full
            gameOverText.text = "ORDER DELIVERED!";
            artifactsText.text = artifactsCollected.ToString() + " ARTIFACT(S) COLLECTED!";
            int wizardColour = Random.Range(0, 3);
            switch (wizardColour)
            {
                case 0: wizardImage.sprite = purpleWizard; break;
                case 1: wizardImage.sprite = blueWizard; break;
                case 2: wizardImage.sprite = brownWizard; break;
            }

            switch(artifactsCollected)
            {
                case 0: wizardText.text = "What are these?! I have never ordered any of it!"; break;
                case 1: wizardText.text = "Well, that's better than nothing right? Thanks."; break;
                case 2: wizardText.text = "Thank you! This is almost everything I have needed!"; break;
                case 3: wizardText.text = "Thank you very much! This is exactly what I needed!"; break;
            }

            wizardImage.enabled = true;
            speachBubbleImage.enabled = true;
            wizardText.enabled = true;
        }
    }

    //restarting the game on button click
    public void NewOrderButton()
    {
        SceneManager.LoadScene("Main"); //reloading scene
        Time.timeScale = 1; //resuming time
    }
}
