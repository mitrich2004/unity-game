using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Artifact : MonoBehaviour
{   
    //artifact sprite randomizer
    int chooseArtifact;

    //sprites of artifacts
    public Sprite shinyFlower;
    public Sprite shinySpider;
    public Sprite shinyHat;
    public Sprite shinyCandle;
    public Sprite shinyPotion;
    public Sprite shinyDagger;
    public Sprite shinyCrystalBall;
    public Sprite shinyRubin;

    //other classes references
    private Inventory inventory;
    private Order order;

    //order complition flag
    private bool allCollected;

    private Sprite[] artifactsSprites;

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
            case 0: artifactSpriteRenderer.sprite = shinyFlower; break; 
            case 1: artifactSpriteRenderer.sprite = shinySpider; break;
            case 2: artifactSpriteRenderer.sprite = shinyHat; break;
            case 3: artifactSpriteRenderer.sprite = shinyCandle; break; 
            case 4: artifactSpriteRenderer.sprite = shinyPotion; break; 
            case 5: artifactSpriteRenderer.sprite = shinyDagger; break; 
            case 6: artifactSpriteRenderer.sprite = shinyCrystalBall; break; 
            case 7: artifactSpriteRenderer.sprite = shinyRubin; break; 
        }

        artifactsSprites = new Sprite[] { order.flower, order.spider, order.hat, order.candle, order.potion, order.dagger, order.crystalBall, order.rubin};
    }

    //calles every time something touches the artifact
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < order.orderedArtifacts.Length; i++)
            {
                if (order.isCollected[i] == false)
                {
                    Sprite orderedArtifactSprite = order.orderedArtifacts[i].GetComponent<Image>().sprite;
                    SpriteRenderer artifactSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                    if (artifactSpriteRenderer.sprite.name.Contains(orderedArtifactSprite.name))
                    {
                        fillTheOrder(i);
                        break;
                    }
                }
            }

            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    collectArtifact(i);
                    break;
                }
            }

            Destroy(gameObject); //destroying the artifact when player touches it
        }
    }

    //player tries to pick up an artifact
    void collectArtifact(int slotIndex)
    {
        inventory.isFull[slotIndex] = true;

        SpriteRenderer artifactSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        for (int i = 0; i < artifactsSprites.Length; ++i)
        {
            if (artifactSpriteRenderer.sprite.name.Contains(artifactsSprites[i].name))
            {
                inventory.items[slotIndex].GetComponent<Image>().sprite = artifactsSprites[i];
            }
        }

        bool allFull = true;

        for (int i = 0; i < inventory.isFull.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                allFull = false;
            }
        }

        if (allFull && !allCollected)
        {
            SceneManager.LoadScene("Main");
            Debug.Log("DEFEAT!!!");
        }
    }

    //player picked up an artifact which was ordered
    void fillTheOrder(int artifactIndex)
    {
        order.isCollected[artifactIndex] = true;
        order.orderedArtifacts[artifactIndex].GetComponent<Image>().color = new Color(255, 255, 255, 0.4f);
        allCollected = true;

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
