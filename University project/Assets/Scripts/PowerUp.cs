using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    //references to other classes
    private Health health;
    private Player player;

    //power up randomizer
    int randomPowerUp;

    //game object elements
    public Sprite heart;
    public Sprite shield;
    private SpriteRenderer powerUpSpriteRender;

    // Start is called before the first frame update
    void Start()
    {
        //initializing fields
        powerUpSpriteRender = gameObject.GetComponent<SpriteRenderer>();

        //choosing random powerUp sprite
        randomPowerUp = Random.Range(0, 2);
        switch (randomPowerUp)
        {
            case 0: powerUpSpriteRender.sprite = heart; break;
            case 1: powerUpSpriteRender.sprite = shield; break;
            default:break;
        }

        //references intialization
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (powerUpSpriteRender.sprite == heart)
            {
                applyHeartPowerUp(); //apply the heart power up
                Destroy(gameObject); //destroying the heart when player touches it
            }
            else
            {
                StartCoroutine(applyShieldPowerUp()); //apply the shield power up
            }
        }
    }

    //player gets a heart powerUp
    void applyHeartPowerUp()
    {
        //go through the list of hearts
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

    //player gets a shield power up
    public IEnumerator applyShieldPowerUp()
    {
        player.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 1f, 1f); //change player color
        tag = "coroutineCaller"; //set coroutine tag to avoid deestruction
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f); //make shield power up trasnparent
        player.shieldActive = true; //set the shield effect up

        yield return new WaitForSeconds(5f); //wait 5 seconds

        player.shieldActive = false; //remove shield effect
        player.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0f, 0.5f, 1f); //change color back
        Destroy(gameObject); //destroy the shield power up
    }
}


