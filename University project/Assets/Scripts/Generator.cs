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
    public GameObject smallObstacle;
    public GameObject flyingObstacle;
    public GameObject longObstacle;
    public GameObject groundObstacle;

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
        chooseObject = Random.Range(0,7);
        if (chooseObject == 0) { GameObject newObject = Instantiate(lowPlatform); }
        if (chooseObject == 1) { GameObject newObject = Instantiate(twoPlatforms); }
        if (chooseObject == 2) { GameObject newObject = Instantiate(threePlatforms); }
        if (chooseObject == 3) { GameObject newObject = Instantiate(smallObstacle); }
        if (chooseObject == 4) { GameObject newObject = Instantiate(flyingObstacle); }
        if (chooseObject == 5) { GameObject newObject = Instantiate(longObstacle);}
        if (chooseObject == 6) { GameObject newObject = Instantiate(groundObstacle);}
    }
}
