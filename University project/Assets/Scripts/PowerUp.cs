using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{

    private Health health;

    public Sprite heart;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer powerUpSpriteRender = gameObject.GetComponent<SpriteRenderer>();
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
            for (int i = health.hearts.Length - 1; i >= 0; i--)
            {
                if (health.isLife[i] == false)
                {
                    health.isLife[i] = true;
                    Image heartImage = health.hearts[i].GetComponent<Image>();
                    heartImage.sprite = heart; //makes the heart image on the screen trasparent
                    break;
                }
            }

            Destroy(gameObject); //destroying the heart when player touches it
        }
    }
}
