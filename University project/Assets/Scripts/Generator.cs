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
    public GameObject powerUp;
    public Animator animator;

    //randomizers
    int chooseObject;
    int chooseArtifactGenerationCase;

    //platforms X coordinates
    const float firstPlatformX = 12f;
    const float secondPlatformX = 17.2f;
    const float thirdPlatformX = 22.5f;

    //platforms Y coordiantes
    const float underLowPlatformY = -2.5f;
    const float onLowPlatformY = -0.2f;
    const float onHighPlatformY = 2.4f;

    // Start is called before the first frame update
    void Start()
    {
        maxTime = 1.5f; //setting generations interval
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

    //generates a game object
    void Generate()
    {
        chooseObject = Random.Range(0, 8); //choose a random object to generate

        if (chooseObject == 0) {
            GameObject newPlatform = Instantiate(lowPlatform); //generate a low platform
            chooseArtifactGenerationCase = Random.Range(0, 2); //choose a random artifact generation case
            switch (chooseArtifactGenerationCase)
            {
                case 0: GenerateArtifactOrPowerUp(firstPlatformX, underLowPlatformY); break; //one artifact under 1st platform
                case 1: GenerateArtifactOrPowerUp(firstPlatformX, onLowPlatformY); break; //one artifact on 1st platform
            }
        }
        else if (chooseObject == 1) 
        {
            GameObject newPlatform = Instantiate(twoPlatforms); //generate two platforms
            chooseArtifactGenerationCase = Random.Range(0, 5); //choose a random artifact generation case
            switch (chooseArtifactGenerationCase)
            {
                case 0: GenerateArtifactOrPowerUp(firstPlatformX, underLowPlatformY); break; //one artifact under 1st platform
                case 1: GenerateArtifactOrPowerUp(firstPlatformX, onLowPlatformY); break; //one artifact on 1st platform
                case 2: GenerateArtifactOrPowerUp(secondPlatformX, onHighPlatformY); break; //one artifact on 2nd platform
                case 3: GenerateArtifactOrPowerUp(firstPlatformX, underLowPlatformY);
                    GenerateArtifactOrPowerUp(secondPlatformX, onHighPlatformY); break; //two artifacts on 1st & 2nd platforms
                case 4: GenerateArtifactOrPowerUp(firstPlatformX, underLowPlatformY);
                    GenerateArtifactOrPowerUp(secondPlatformX, onHighPlatformY); break; //two artifacts under 1st platform & on 2nd platform
            }
        }
        else if (chooseObject == 2)
        {
            GameObject newPlatform = Instantiate(threePlatforms); //generate two platforms
            chooseArtifactGenerationCase = Random.Range(0, 12); //choose a random artifact generation case
            switch (chooseArtifactGenerationCase)
            {
                case 0: GenerateArtifactOrPowerUp(firstPlatformX, onLowPlatformY); break; //one artifact on 1st platform
                case 1: GenerateArtifactOrPowerUp(secondPlatformX, onHighPlatformY); break; //one artifact on 2nd platform
                case 2: GenerateArtifactOrPowerUp(thirdPlatformX, onLowPlatformY); break; //one artifact on 3d platform
                case 3: GenerateArtifactOrPowerUp(firstPlatformX, underLowPlatformY);
                    GenerateArtifactOrPowerUp(secondPlatformX, onHighPlatformY); break; //two artifacts on 1st & 2nd platforms
                case 4: GenerateArtifactOrPowerUp(firstPlatformX, underLowPlatformY);
                    GenerateArtifactOrPowerUp(secondPlatformX, onHighPlatformY); break; //two artifacts under 1st platform & on 2nd platform
                case 5: GenerateArtifactOrPowerUp(firstPlatformX, onLowPlatformY);
                    GenerateArtifactOrPowerUp(thirdPlatformX, onLowPlatformY); break; //two artifacts on 1st & 3d platforms
                case 6: GenerateArtifactOrPowerUp(firstPlatformX, underLowPlatformY);
                    GenerateArtifactOrPowerUp(thirdPlatformX, underLowPlatformY); break; //two artifacts under 1st & 3d platforms
                case 7: GenerateArtifactOrPowerUp(firstPlatformX, onLowPlatformY);
                    GenerateArtifactOrPowerUp(thirdPlatformX, underLowPlatformY); break; //two artifacts on 1st platform & under 3d platform
                case 8: GenerateArtifactOrPowerUp(firstPlatformX, underLowPlatformY);
                    GenerateArtifactOrPowerUp(thirdPlatformX, onLowPlatformY); break; //two artifacts under 1st platform & on 3d platform
                case 9: GenerateArtifactOrPowerUp(secondPlatformX, onHighPlatformY);
                    GenerateArtifactOrPowerUp(thirdPlatformX, onLowPlatformY); break; //two artifacts on 2nd platform & on 3d platform
                case 10: GenerateArtifactOrPowerUp(secondPlatformX, onHighPlatformY);
                    GenerateArtifactOrPowerUp(thirdPlatformX, underLowPlatformY); break; //two artifacts on 2nd platform & under 3d platform
                case 11: GenerateArtifactOrPowerUp(firstPlatformX, onLowPlatformY);
                    GenerateArtifactOrPowerUp(secondPlatformX, onHighPlatformY);
                    GenerateArtifactOrPowerUp(thirdPlatformX, onLowPlatformY); break; //three artifacts on 1st, 2nd & 3d platforms
            }
        }
        
        if (chooseObject == 3) 
        { 
            GameObject newObstacle = Instantiate(smallObstacle); //generate small obstacle
        }

        if (chooseObject == 4) 
        {
            GameObject newObstacle = Instantiate(flyingObstacle); //generate flying obstacle
            if (animator != null && animator.isActiveAndEnabled)
            {
                animator.Play("bat");
            }
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

    //generates an artifact
    void GenerateArtifactOrPowerUp(float x, float y)
    {
        int artifactOrPowerUp = Random.Range(0, 9);
        if (artifactOrPowerUp == 0)
        {
            GameObject newPowerUp = Instantiate(powerUp); //generate powerUp
            newPowerUp.gameObject.transform.position = new Vector2(x, y); //set powerUp's position
        }
        else
        {
            GameObject newArtifact = Instantiate(artifact); //create artifact
            newArtifact.gameObject.transform.position = new Vector2(x, y); //set artifact's position
        }
    }
}

