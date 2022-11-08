using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Artifact : MonoBehaviour
{   
    //artifact sprite randomizer
    int chooseArtifact;
    
    //other classes references
    private Inventory inventory;
    private Order order;

    // Start is called before the first frame update
    void Start()
    {
        //intializing references
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        order = GameObject.FindGameObjectWithTag("Player").GetComponent<Order>();

        chooseArtifact = Random.Range(0, 8); //choosing a random sprite
        SpriteRenderer artifactSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        //sets the sprite for the artifact
        switch (chooseArtifact)
        {
            case 0: artifactSpriteRenderer.sprite = order.flower; break; 
            case 1: artifactSpriteRenderer.sprite = order.spider; break;
            case 2: artifactSpriteRenderer.sprite = order.hat; break;
            case 3: artifactSpriteRenderer.sprite = order.scorpio; break; 
            case 4: artifactSpriteRenderer.sprite = order.potion; break; 
            case 5: artifactSpriteRenderer.sprite = order.dagger; break; 
            case 6: artifactSpriteRenderer.sprite = order.wand; break; 
            case 7: artifactSpriteRenderer.sprite = order.rubin; break; 
        }
    }

    //calles every time something touches the artifact
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    collectArtifact(i);
                    break;
                }
            }

            for (int i = 0; i < order.orderedArtifacts.Length; i++)
            {
                if (order.isCollected[i] == false)
                {
                    Sprite orderedArtifactSprite = order.orderedArtifacts[i].GetComponent<Image>().sprite;
                    SpriteRenderer artifactSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                    if (orderedArtifactSprite.name == artifactSpriteRenderer.sprite.name)
                    {
                        fillTheOrder(i);
                        break;
                    }
                }          
            }

            Destroy(gameObject); //destroying the artifact when player touches it
        }
    }

    //player tries to pick up an artifact
    void collectArtifact(int slotIndex)
    {
        inventory.isFull[slotIndex] = true;
        inventory.slots[slotIndex].GetComponent<Image>().sprite = 
            gameObject.GetComponent<SpriteRenderer>().sprite;
        bool allFull = true;

        for (int i = 0; i < inventory.isFull.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                allFull = false;
            }
        }

        if (allFull)
        {
            SceneManager.LoadScene("Main");
            Debug.Log("DEFEAT!!!");
        }
    }

    //player picked up an artifact which was ordered
    void fillTheOrder(int artifactIndex)
    {
        order.isCollected[artifactIndex] = true;
        order.orderedArtifacts[artifactIndex].GetComponent<Image>().color = new Color(255, 255, 255, 0.2f);
        bool allCollected = true;

        for (int j = 0; j < order.isCollected.Length; j++)
        {
            if (order.isCollected[j] == false)
            {
                allCollected = false;
            }
        }

        if (allCollected)
        {
            SceneManager.LoadScene("Main");
            Debug.Log("VICTORY!!!");
        }
    }
}
