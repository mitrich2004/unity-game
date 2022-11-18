using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEditor.Experimental.GraphView;
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
    public Sprite scorpio;
    public Sprite potion;
    public Sprite dagger;
    public Sprite wand;
    public Sprite rubin;

    // Start is called before the first frame update
    private void Start()
    {
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
                case 3: orderedArtifactImage.sprite = scorpio; break;
                case 4: orderedArtifactImage.sprite = potion; break;
                case 5: orderedArtifactImage.sprite = dagger; break;
                case 6: orderedArtifactImage.sprite = wand; break;
                case 7: orderedArtifactImage.sprite = rubin; break;
            }
        }
    }
}