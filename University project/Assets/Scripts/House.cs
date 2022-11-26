using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    //other classes references
    private Order order;
    private GameOverScreen gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        //initializing references
        order = GameObject.FindGameObjectWithTag("Player").GetComponent<Order>();
        gameOverScreen = GameObject.FindGameObjectWithTag("Player").GetComponent<GameOverScreen>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //check if player ran to the house
        if (other.CompareTag("Player"))
        {
            gameOverScreen.showGameOverScreen(order.artifactsCollected); //show final screen
        }
    }
}
