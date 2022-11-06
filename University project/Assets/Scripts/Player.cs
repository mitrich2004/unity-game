using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //player object features
    Rigidbody2D rb;
    public LayerMask platformsAndGroundLayerMask;
    private BoxCollider2D boxCollider2d;

    //space key flag
    private bool jumpKeyWasPressed;

    private Health health;

    // Start is called before the first frame update
    void Start()
    {
        //intializing the features
        rb = GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            jumpKeyWasPressed = true; //the space key has been pressed
        }
    }

    private void FixedUpdate()
    {
        if (IsGrounded() && jumpKeyWasPressed)
        {
            rb.velocity = new Vector3(0, 20, 0); //make the player jump
            jumpKeyWasPressed = false;  //disable the multijuming
        }
    }

    private bool IsGrounded()
    {
        //check if player touches the ground or a platform
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, 0.1f, platformsAndGroundLayerMask);
        return raycastHit2d.collider != null; 
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("obstacle"))
        {
            for(int i=0; i<health.hearts.Length; i++)
            {
                if (health.isLife[i] == true)
                {
                    health.isLife[i] = false;
                    Destroy(health.hearts[i]);
                    if (i == 2)
                    {
                        SceneManager.LoadScene("Main");

                    }
                    break;
                }
            }
        }
    }


}
