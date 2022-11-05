using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    //all arificat sprites
    public Sprite hexagon;
    public Sprite flower;

    //artifact sprite randomizer
    int chooseArtifact;

    // Start is called before the first frame update
    void Start()
    {
        chooseArtifact = Random.Range(0, 2); //choosing a random sprite

        switch (chooseArtifact)
        {
            case 0: gameObject.GetComponent<SpriteRenderer>().sprite = hexagon; break; //hexagon
            case 1: gameObject.GetComponent<SpriteRenderer>().sprite = flower; break; //flower

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
        if (c2d.CompareTag("Player"))
        {
            Destroy(gameObject); //destroying the artifact when player touches it
        }
    }
}
