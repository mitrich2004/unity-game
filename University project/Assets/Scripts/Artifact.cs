using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Artifact : MonoBehaviour
{
    //all arificat sprites
    public Sprite flower;
    public Sprite spider;
    public Sprite hat;
    public Sprite scorpio;
    public Sprite potion;
    public Sprite dagger;
    public Sprite wand;
    public Sprite rubin;
    
    //artifact sprite randomizer
    int chooseArtifact;
    
    //invenotry reference
    private Inventory inventory;

    //saving the artifact sprite here
    private Sprite artifactSprite;

    // Start is called before the first frame update
    void Start()
    {
        chooseArtifact = Random.Range(0, 8); //choosing a random sprite
        switch (chooseArtifact)
        {
            case 0: gameObject.GetComponent<SpriteRenderer>().sprite = flower; artifactSprite = flower; break; 
            case 1: gameObject.GetComponent<SpriteRenderer>().sprite = spider; artifactSprite = spider; break;
            case 2: gameObject.GetComponent<SpriteRenderer>().sprite = hat; artifactSprite = hat; break;
            case 3: gameObject.GetComponent<SpriteRenderer>().sprite = scorpio; artifactSprite = scorpio; break; 
            case 4: gameObject.GetComponent<SpriteRenderer>().sprite = potion; artifactSprite = potion; break; 
            case 5: gameObject.GetComponent<SpriteRenderer>().sprite = dagger; artifactSprite = dagger; break; 
            case 6: gameObject.GetComponent<SpriteRenderer>().sprite = wand; artifactSprite = wand; break; 
            case 7: gameObject.GetComponent<SpriteRenderer>().sprite = rubin; artifactSprite = rubin; break; 
        }

        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    inventory.slots[i].GetComponent<Image>().sprite = artifactSprite;
                    break;
                }
            }
            Destroy(gameObject); //destroying the artifact when player touches it
        }
    }
}
