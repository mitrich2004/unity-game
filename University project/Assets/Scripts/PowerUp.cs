using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    //references to other classes
    private Health health;

    //game object elements
    public Sprite heart;
    private SpriteRenderer powerUpSpriteRender;

    // Start is called before the first frame update
    void Start()
    {
        //initializing fields
        powerUpSpriteRender = gameObject.GetComponent<SpriteRenderer>();
        powerUpSpriteRender.sprite = heart;
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (powerUpSpriteRender.sprite == heart)
            {
                applyHeartPowerUp(); //apply the power up
            }
            Destroy(gameObject); //destroying the heart when player touches it
        }
    }

    //player gets a heart powerUp
    void applyHeartPowerUp()
    {
        for (int i = health.hearts.Length - 1; i >= 0; i--)
        {
            //checks if there is an empty heart
            if (health.isLife[i] == false)
            {
                //recovers a heart
                health.isLife[i] = true;
                Image heartImage = health.hearts[i].GetComponent<Image>();
                heartImage.sprite = heart; 
                break;
            }
        }
    }
}


