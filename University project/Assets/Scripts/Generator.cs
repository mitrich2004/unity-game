using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    float maxTime;
    float timer;

    public GameObject lowPlatform; 
    public GameObject twoPlatforms;
    public GameObject threePlatforms;

    int chooseObject;

    // Start is called before the first frame update
    void Start()
    {
        maxTime = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > maxTime)
        {
            Generate();
            timer = 0;
        }
        
    }

    void Generate()
    {
        chooseObject = Random.Range(0, 3);
        if (chooseObject == 0) { GameObject newObject = Instantiate(lowPlatform); }
        if (chooseObject == 1) { GameObject newObject = Instantiate(twoPlatforms); }
        if (chooseObject == 2) { GameObject newObject = Instantiate(threePlatforms); }

    }
}
