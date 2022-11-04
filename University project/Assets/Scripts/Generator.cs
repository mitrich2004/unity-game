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
    public GameObject artifact;

    int chooseObject;
    int choosePosition;

    // Start is called before the first frame update
    void Start()
    {
        maxTime = 2.2f;
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
         chooseObject = Random.Range(0,8);
          if (chooseObject == 0) {
              GameObject newArtifact = Instantiate(artifact);
              choosePosition = Random.Range(0, 3);
              if (choosePosition == 0)
              {
              newArtifact.transform.position = new Vector2(12.7f, 0.4f);
              }
              else if(choosePosition == 1)
              {
              GameObject newArtifact2 = Instantiate(artifact);
              newArtifact.transform.position = new Vector2(12.7f, 0.4f);
          }

              GameObject newObject = Instantiate(lowPlatform);
          }



           if (chooseObject == 1) {
               GameObject newArtifact = Instantiate(artifact);
               choosePosition = Random.Range(0, 5);
               if (choosePosition == 0)
               {
                   newArtifact.transform.position = new Vector2(12.7f, 0.4f);
               }
               else if(choosePosition == 1)
               {
                   newArtifact.transform.position = new Vector2(17.9f, 2.9f);
               }
               else if(choosePosition == 2)
               {
               GameObject newArtifact2 = Instantiate(artifact);
               newArtifact.transform.position = new Vector2(12.7f, 0.4f);
               }
               else if(choosePosition == 3)
               {
               GameObject newArtifact2 = Instantiate(artifact);
               newArtifact.transform.position = new Vector2(12.7f, 0.4f);
               newArtifact2.transform.position = new Vector2(17.9f, 2.9f);
               }
               else if(choosePosition == 4)
               {
               GameObject newArtifact2 = Instantiate(artifact);
               newArtifact.transform.position = new Vector2(17.9f, 2.9f);
               }
               GameObject newObject = Instantiate(twoPlatforms); 
           }



        if (chooseObject == 2){
            GameObject newObject = Instantiate(threePlatforms);
        GameObject newArtifact = Instantiate(artifact);
        choosePosition = Random.Range(0, 12);
        if (choosePosition == 0)
        {
            newArtifact.transform.position = new Vector2(12.7f, 0.4f);  //over 1
        }
        else if (choosePosition == 1)
        {
            newArtifact.transform.position = new Vector2(17.9f, 2.9f);  //over 2
        }
        else if (choosePosition == 2)
        {
          
            newArtifact.transform.position = new Vector2(23.2f, 0.4f);  //over 3
        }
        else if (choosePosition == 3)
        {
            GameObject newArtifact2 = Instantiate(artifact);
            newArtifact.transform.position = new Vector2(12.7f, 0.4f);  //over 1
            newArtifact2.transform.position = new Vector2(17.9f, 2.9f);  //over 2
        }
        else if (choosePosition == 4)
        {
            GameObject newArtifact2 = Instantiate(artifact);  
            newArtifact.transform.position = new Vector2(17.9f, 2.9f);  //over 2
        }
        else if(choosePosition == 5)
        {
            newArtifact.transform.position = new Vector2(12.7f, 0.4f); //over 1
            GameObject newArtifact2 = Instantiate(artifact); 
            newArtifact2.transform.position = new Vector2(23.2f, 0.4f);  //over 3
        }
        else if(choosePosition == 6)
        {
            GameObject newArtifact2 = Instantiate(artifact);
            newArtifact2.transform.position = new Vector2(23.2f, -2); // under 3
        }
        else if (choosePosition == 7)
        {
            newArtifact.transform.position = new Vector2(12.7f, 0.4f); //over 1
            GameObject newArtifact2 = Instantiate(artifact);
            newArtifact2.transform.position = new Vector2(23.2f, -2f);  //under 3
        }
        else if (choosePosition == 8)
        {
            GameObject newArtifact2 = Instantiate(artifact);
            newArtifact2.transform.position = new Vector2(23.2f, 0.4f); //over 3
        }
        else if (choosePosition == 9)
        {
            newArtifact.transform.position = new Vector2(17.9f, 2.9f);  //over 2
            GameObject newArtifact2 = Instantiate(artifact);
            newArtifact2.transform.position = new Vector2(23.2f, 0.4f);  //over 3
        }
        else if (choosePosition == 10)
        {
            newArtifact.transform.position = new Vector2(17.9f, 2.9f);  //over 2
            GameObject newArtifact2 = Instantiate(artifact);
            newArtifact2.transform.position = new Vector2(23.2f, -2f);  //under 3
        }
        else if (choosePosition == 11)
        {
            newArtifact.transform.position = new Vector2(12.7f, 0.4f);  //over 1
            GameObject newArtifact2 = Instantiate(artifact);
            newArtifact2.transform.position = new Vector2(17.9f, 2.9f);  //over 2
            GameObject newArtifact3 = Instantiate(artifact);
            newArtifact3.transform.position = new Vector2(23.2f, 0.4f);  //over 3

        }



              }
             if (chooseObject == 3) { GameObject newObject = Instantiate(smallObstacle); }
             if (chooseObject == 4) { GameObject newObject = Instantiate(flyingObstacle); }
             if (chooseObject == 5) { GameObject newObject = Instantiate(longObstacle);}
             if (chooseObject == 6) { GameObject newObject = Instantiate(groundObstacle);}
             if (chooseObject == 7) { GameObject newArtifact = Instantiate(artifact); }



    }
}
