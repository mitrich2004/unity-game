using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{

    public Sprite hexagon;
    public Sprite flower;
    int chooseArtifact;

    // Start is called before the first frame update
    void Start()
    {
        chooseArtifact = Random.Range(0, 2);
        if (chooseArtifact == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = hexagon;
        }
        else if (chooseArtifact == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = flower;
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
            Destroy(gameObject);
        }
    }
}
