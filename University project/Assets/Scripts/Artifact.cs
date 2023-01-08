using UnityEngine;
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
    private GameOverScreen gameOverScreen;
    private Generator generator;

    //order complition flag
    private bool allCollected;
    
    //array of artifacts images
    private Sprite[] artifactsSprites;

    // Start is called before the first frame update
    void Start()
    {
        //intializing references
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        order = GameObject.FindGameObjectWithTag("Player").GetComponent<Order>();
        gameOverScreen = GameObject.FindGameObjectWithTag("Player").GetComponent<GameOverScreen>();
        generator = GameObject.FindGameObjectWithTag("generator").GetComponent<Generator>();

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

        //filing the array of images
        artifactsSprites = new Sprite[] { order.flower, order.spider, order.hat, order.candle, order.potion, order.dagger, order.crystalBall, order.rubin};
    }

    // Update is called once per frame
    void Update()
    {
        //checks if the game is over
        if (gameOverScreen.gameOver == true)
        {
            Destroy(gameObject); //destroys every artifact that's left
        }
    }

    //calles every time something touches the artifact
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //checks all ordered artifacts
            for (int i = 0; i < order.orderedArtifacts.Length; i++)
            {
                //check if this ordered artifacts has been already collected
                if (order.isCollected[i] == false)
                {
                    //getting artifact images
                    Sprite orderedArtifactSprite = order.orderedArtifacts[i].GetComponent<Image>().sprite;
                    SpriteRenderer artifactSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();

                    //checks if player collected the ordered artifact
                    if (artifactSpriteRenderer.sprite.name.Contains(orderedArtifactSprite.name))
                    {
                        fillTheOrder(i);
                        break;
                    }
                }
            }

            //goes through the imvemotry slots
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                //finds the first free slot
                if (inventory.isFull[i] == false)
                {
                    collectArtifact(i);
                    break;
                }
            }

            Destroy(gameObject); //destroying the artifact when player touches it
        }
    }

    //player picks up an artifact
    void collectArtifact(int slotIndex)
    {
        //fill the slot
        inventory.isFull[slotIndex] = true;

        SpriteRenderer artifactSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        //goes through all artifacts images
        for (int i = 0; i < artifactsSprites.Length; ++i)
        {
            //finds the right artifact image
            if (artifactSpriteRenderer.sprite.name.Contains(artifactsSprites[i].name))
            {
                inventory.items[slotIndex].GetComponent<Image>().sprite = artifactsSprites[i];
            }
        }

        bool allFull = true;

        //checks if there are free slots left
        for (int i = 0; i < inventory.isFull.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                allFull = false;
            }
        }

        //checks if inventory is full and if the order is completed
        if (allFull && !allCollected)
        {
            //game over
            Destroy(generator);
            gameOverScreen.SetUp(); //shows game over screen
        }
    }

    //player picked up an artifact which was ordered
    void fillTheOrder(int artifactIndex)
    {
        order.artifactsCollected += 1; //increase number of ordered arifacts collected
        order.isCollected[artifactIndex] = true; //sets artifact to collected
        order.orderedArtifacts[artifactIndex].GetComponent<Image>().color = new Color(255, 255, 255, 0.4f); //makes it image transparent
        
        //assumption
        allCollected = true; 

        //goes through the order list
        for (int j = 0; j < order.isCollected.Length; j++)
        {
            //checks if there is an artifacts not yet collected
            if (order.isCollected[j] == false)
            {
                allCollected = false;
            }
        }

        //checks if all ordered artifacts have been collected
        if (allCollected)
        {
            //game over
            Destroy(generator); //destroys the generator
            gameOverScreen.SetUp(); //shows game over screen
        }
    }
}
