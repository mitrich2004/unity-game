using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    //important parameters
    private float speed;
    public float start;
    public float end;

    // Start is called before the first frame update
    void Start()
    {
        speed = 12f; //setting the speed
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y); //moving the object
        if (transform.position.x <= end)
        {
            if (gameObject.tag == "platform" || gameObject.tag == "artifact" || gameObject.tag == "obstacle")
            {
                Destroy(gameObject); //destroying the object, once it's out of the view
            }
            else
            {
                transform.position = new Vector2(start, transform.position.y); //repositioning the object back to the start
            }
        }
    }
}

