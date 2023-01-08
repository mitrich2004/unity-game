using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    //arrays storing ordered items and their status
    public bool[] isCollected;
    public GameObject[] orderedArtifacts;
    
    //size of order and order randomizer
    private int sizeOfOrder;
    private int chooseOrderedArtifact;

    //sprites of artifacts
    public Sprite flower;
    public Sprite spider;
    public Sprite hat;
    public Sprite candle;
    public Sprite potion;
    public Sprite dagger;
    public Sprite crystalBall;
    public Sprite rubin;

    //number of ordered artifacts collected
    public int artifactsCollected;

    // Start is called before the first frame update
    private void Start()
    {
        artifactsCollected = 0; //no artifacts are collected at the start
        sizeOfOrder = 3; //sets the number of artifacts in the order
        for (int i = 0; i < sizeOfOrder; ++i)
        {
            chooseOrderedArtifact = Random.Range(0, 8); //choose a random artifact to order
            Image orderedArtifactImage = orderedArtifacts[i].GetComponent<Image>();

            //sets the sprites to the images
            switch (chooseOrderedArtifact)
            {
                case 0: orderedArtifactImage.sprite = flower; break;
                case 1: orderedArtifactImage.sprite = spider; break;
                case 2: orderedArtifactImage.sprite = hat; break;
                case 3: orderedArtifactImage.sprite = candle; break;
                case 4: orderedArtifactImage.sprite = potion; break;
                case 5: orderedArtifactImage.sprite = dagger; break;
                case 6: orderedArtifactImage.sprite = crystalBall; break;
                case 7: orderedArtifactImage.sprite = rubin; break;
            }
        }
    }
}
