using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //player object features
    Rigidbody2D rb;
    public LayerMask platformsAndGroundLayerMask;
    private BoxCollider2D boxCollider2d;

    //space key flag
    private bool jumpKeyWasPressed;

    //references to other classes
    private Health health;
    private GameOverScreen gameOverScreen;

    //sprites
    public Sprite empty;

    // Start is called before the first frame update
    void Start()
    {
        //intializing the features
        rb = GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        gameOverScreen = GameObject.FindGameObjectWithTag("Player").GetComponent<GameOverScreen>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            jumpKeyWasPressed = true; //the space key has been pressed
        }
    }

    //Called every fixed amount of time
    private void FixedUpdate()
    {
        if (IsGrounded() && jumpKeyWasPressed)
        {
            rb.velocity = new Vector3(0, 20, 0); //make the player jump
            jumpKeyWasPressed = false;  //disable the multijuming
        }
    }

    //Checks if player touches the ground or a platform
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center,
            boxCollider2d.bounds.size, 0f, Vector2.down, 0.1f, platformsAndGroundLayerMask);
        return raycastHit2d.collider != null; 
    }

    //Called every time a player touches something
    void OnTriggerEnter2D(Collider2D other)
    {
        //checks if player touched an obstacle
        if (other.CompareTag("obstacle"))
        {
            for(int i=0; i<health.hearts.Length; i++)
            {
                if (health.isLife[i] == true)
                {
                    decreaseLives(i); //take one heart away
                    break;
                }
            }
        }
    }

    //Deducts one life from a player
    void decreaseLives(int heartIndex)
    {
        health.isLife[heartIndex] = false; //sets the heart existence to false
        Image heartImage = health.hearts[heartIndex].GetComponent<Image>();
        heartImage.sprite = empty; //makes the heart image on the screen trasparent

        //checks if player lost the last heart
        if (heartIndex == 2)
        {
            //game over
            Time.timeScale = 0; //stops time
            gameOverScreen.SetUp(-1); //shows game over screen
        }
    }
}
