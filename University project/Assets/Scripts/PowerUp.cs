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

    // Update is called once per frame
    void Update()
    {
        
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

    void applyHeartPowerUp()
    {
     
        for (int i = health.hearts.Length - 1; i >= 0; i--)
        {
            if (health.isLife[i] == false)
            {
                health.isLife[i] = true;
                Image heartImage = health.hearts[i].GetComponent<Image>();
                heartImage.sprite = heart; //returns the heart image
                break;
            }
        }
    }
}


