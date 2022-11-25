using System.Collections;
using System.Collections.Generic;
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

        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (powerUpSpriteRender.sprite == heart)
            {
                applyHeartPowerUp(); //apply the power up
                Destroy(gameObject); //destroying the heart when player touches it
            }
            else
            {
                StartCoroutine(applyShieldPowerUp());
            }

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

    public IEnumerator applyShieldPowerUp()
    {
        player.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 1f, 1f);
        tag = "collectedShield";
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        player.shieldActive = true;
        yield return new WaitForSeconds(5f);
        player.shieldActive = false;
        //tag = "powerUp";
        player.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0f, 0.5f, 1f);
        Destroy(gameObject);
    }
}


