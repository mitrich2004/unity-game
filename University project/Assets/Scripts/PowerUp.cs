using System.Collections;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    //references to other classes
    private Health health;
    private Player player;
    private Inventory inventory;
    private GameOverScreen gameOverScreen;
    private Order order;
    public GameObject artifact;

    //power up randomizer
    int randomPowerUp;
    Sprite[] orderedArtifactsSprites;

    //game object elements
    public Sprite heart;
    public Sprite shield;
    public Sprite bin;
    public Sprite mystery;
    public Sprite transparent;
    private SpriteRenderer powerUpSpriteRender;

    // Start is called before the first frame update
    void Start()
    {
        //initializing fields
        powerUpSpriteRender = gameObject.GetComponent<SpriteRenderer>();

        //choosing random powerUp sprite
        randomPowerUp = Random.Range(0, 4);
        switch (randomPowerUp)
        {
            case 0: powerUpSpriteRender.sprite = heart; break;
            case 1: powerUpSpriteRender.sprite = shield; break;
            case 2: powerUpSpriteRender.sprite = bin; break;
            case 3: powerUpSpriteRender.sprite = mystery; break;
            default:break;
        }

        //references intialization
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        order = GameObject.FindGameObjectWithTag("Player").GetComponent<Order>();
        gameOverScreen = GameObject.FindGameObjectWithTag("Player").GetComponent<GameOverScreen>();

        orderedArtifactsSprites = new Sprite[3];

        for (int i = 0; i < 3; ++i)
        {
            orderedArtifactsSprites[i] = order.orderedArtifacts[i].GetComponent<Image>().sprite;
        }
    }

    private void Update()
    {
        if (gameOverScreen.gameOver == true && powerUpSpriteRender.sprite == bin)
        {
            Destroy(gameObject); //destroys every artifact that's left
        }
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
            else if (powerUpSpriteRender.sprite == shield)
            {
                StartCoroutine(applyShieldPowerUp()); //apply the shield power up
            }
            else if (powerUpSpriteRender.sprite == bin)
            {
                applyBinPowerUp();
                Destroy(gameObject);
            }
            else if (powerUpSpriteRender.sprite == mystery)
            {
                GameObject newArtifact = Instantiate(artifact); //create artifact
                newArtifact.gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y); //set artifact's position
                Destroy(gameObject);
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
        player.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f); //change player color
        tag = "coroutineCaller"; //set coroutine tag to avoid deestruction
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f); //make shield power up trasnparent
        player.shieldActive = true; //set the shield effect up

        yield return new WaitForSeconds(5f); //wait 5 seconds

        player.shieldActive = false; //remove shield effect
        player.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f); //change color back
        Destroy(gameObject); //destroy the shield power up
    }

    void applyBinPowerUp()
    {
        for (int i = inventory.isFull.Length - 1; i >= 0; --i)
        {
            if (inventory.isFull[i] == true)
            {
                Image inventoryIamge = inventory.items[i].GetComponent<Image>();
                int inInventory = 0;
                int inOrder = 0;

                for (int j = 0; j < 3; ++j)
                {
                    if (inventoryIamge.sprite.name == orderedArtifactsSprites[j].name)
                    {
                        ++inOrder;
                    }
                }

                for (int k = 0; k < inventory.isFull.Length; k++)
                {
                    if (inventoryIamge.sprite.name == inventory.items[k].GetComponent<Image>().sprite.name)
                    {
                        ++inInventory;
                    }
                }

                if (inInventory > inOrder)
                {
                    inventory.isFull[i] = false;
                    inventoryIamge.sprite = transparent;
                    for (int j = i + 1; j <= 4; ++j)
                    {
                        if (inventory.isFull[j] == true)
                        {
                            inventory.isFull[j] = false;
                            inventory.isFull[j - 1] = true;
                            inventory.items[j-1].GetComponent<Image>().sprite = inventory.items[j].GetComponent<Image>().sprite;
                            inventory.items[j].GetComponent<Image>().sprite = transparent;
                        }
                    }
                    break;
                }
            }
        }
    }
}


