using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    //time fields
    float maxTime;
    float timer;

    //all objects
    public GameObject lowPlatform; 
    public GameObject twoPlatforms;
    public GameObject threePlatforms;
    public GameObject smallObstacle;
    public GameObject flyingObstacle;
    public GameObject longObstacle;
    public GameObject highObstacle;
    public GameObject artifact;

    //randomizers
    int chooseObject;
    int chooseArtifactGenerationCase;

    //platforms X coordinates
    const float firstPlatformX = 12f;
    const float secondPlatformX = 17.2f;
    const float thirdPlatformX = 22.5f;

    //platforms Y coordiantes
    const float underLowPlatformY = -2f;
    const float onLowPlatformY = 0.4f;
    const float onHighPlatformY = 3f;

    // Start is called before the first frame update
    void Start()
    {
        maxTime = 2.2f; //setting generations interval
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; //couning time
        if (timer > maxTime)
        {
            Generate(); //generating an object
            timer = 0; //reseting the timer
        }
        
    }

    void Generate()
    {
        chooseObject = Random.Range(0,8); //choose a random object to generate

        if (chooseObject == 0) {
            GameObject newPlatform = Instantiate(lowPlatform); //generate a low platform
            chooseArtifactGenerationCase = Random.Range(0, 2); //choose a random artifact generation case
            switch (chooseArtifactGenerationCase)
            {
                case 0: GenerateArtifact(firstPlatformX, underLowPlatformY); break; //one artifact under 1st platform
                case 1: GenerateArtifact(firstPlatformX, onLowPlatformY); break; //one artifact on 1st platform
            }
        }
        else if (chooseObject == 1) 
        {
            GameObject newPlatform = Instantiate(twoPlatforms); //generate two platforms
            chooseArtifactGenerationCase = Random.Range(0, 5); //choose a random artifact generation case
            switch (chooseArtifactGenerationCase)
            {
                case 0: GenerateArtifact(firstPlatformX, underLowPlatformY); break; //one artifact under 1st platform
                case 1: GenerateArtifact(firstPlatformX, onLowPlatformY); break; //one artifact on 1st platform
                case 2: GenerateArtifact(secondPlatformX, onHighPlatformY); break; //one artifact on 2nd platform
                case 3: GenerateArtifact(firstPlatformX, underLowPlatformY);
                    GenerateArtifact(secondPlatformX, onHighPlatformY); break; //two artifacts on 1st & 2nd platforms
                case 4: GenerateArtifact(firstPlatformX, underLowPlatformY);
                    GenerateArtifact(secondPlatformX, onHighPlatformY); break; //two artifacts under 1st platform & on 2nd platform
            }
        }
        else if (chooseObject == 2)
        {
            GameObject newPlatform = Instantiate(threePlatforms); //generate two platforms
            chooseArtifactGenerationCase = Random.Range(0, 12); //choose a random artifact generation case
            switch (chooseArtifactGenerationCase)
            {
                case 0: GenerateArtifact(firstPlatformX, onLowPlatformY); break; //one artifact on 1st platform
                case 1: GenerateArtifact(secondPlatformX, onHighPlatformY); break; //one artifact on 2nd platform
                case 2: GenerateArtifact(thirdPlatformX, onLowPlatformY); break; //one artifact on 3d platform
                case 3: GenerateArtifact(firstPlatformX, underLowPlatformY);
                    GenerateArtifact(secondPlatformX, onHighPlatformY); break; //two artifacts on 1st & 2nd platforms
                case 4: GenerateArtifact(firstPlatformX, underLowPlatformY);
                    GenerateArtifact(secondPlatformX, onHighPlatformY); break; //two artifacts under 1st platform & on 2nd platform
                case 5: GenerateArtifact(firstPlatformX, onLowPlatformY);
                    GenerateArtifact(thirdPlatformX, onLowPlatformY); break; //two artifacts on 1st & 3d platforms
                case 6: GenerateArtifact(firstPlatformX, underLowPlatformY);
                    GenerateArtifact(thirdPlatformX, underLowPlatformY); break; //two artifacts under 1st & 3d platforms
                case 7: GenerateArtifact(firstPlatformX, onLowPlatformY);
                    GenerateArtifact(thirdPlatformX, underLowPlatformY); break; //two artifacts on 1st platform & under 3d platform
                case 8: GenerateArtifact(firstPlatformX, underLowPlatformY);
                    GenerateArtifact(thirdPlatformX, onLowPlatformY); break; //two artifacts under 1st platform & on 3d platform
                case 9: GenerateArtifact(secondPlatformX, onHighPlatformY);
                    GenerateArtifact(thirdPlatformX, onLowPlatformY); break; //two artifacts on 2nd platform & on 3d platform
                case 10: GenerateArtifact(secondPlatformX, onHighPlatformY);
                    GenerateArtifact(thirdPlatformX, underLowPlatformY); break; //two artifacts on 2nd platform & under 3d platform
                case 11: GenerateArtifact(firstPlatformX, onLowPlatformY);
                    GenerateArtifact(secondPlatformX, onHighPlatformY);
                    GenerateArtifact(thirdPlatformX, onLowPlatformY); break; //three artifacts on 1st, 2nd & 3d platforms
            }
        }
        
        if (chooseObject == 3) 
        { 
            GameObject newObstacle = Instantiate(smallObstacle); //generate small obstacle
        }

        if (chooseObject == 4) 
        {
            GameObject newObstacle = Instantiate(flyingObstacle); //generate flying obstacle
        }

        if (chooseObject == 5)
        { 
            GameObject newObstacle = Instantiate(longObstacle); //generate long obstacle
        }

        if (chooseObject == 6) 
        { 
            GameObject newObstacle = Instantiate(highObstacle); //generate high obstacle
        }

        if (chooseObject == 7) 
        { 
            GameObject newArtifact = Instantiate(artifact); //generate artifact
        }
    }

    void GenerateArtifact(float x, float y)
    {
        GameObject newArtifact = Instantiate(artifact); //create artifact
        newArtifact.gameObject.transform.position = new Vector2(x, y); //set artifact's position
    }
}

