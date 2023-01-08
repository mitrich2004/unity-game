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
        if (gameObject.tag == "flyingObstacle")
        {
            speed = 14f;
        }
        else
        {
            speed = 12f; //setting the speed
        }
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
            if (gameObject.tag == "background" || gameObject.tag == "ground")
            {
                transform.position = new Vector2(start, transform.position.y); //repositioning the object back to the start
            }
            else
            {
                if (gameObject.tag != "coroutineCaller")
                    Destroy(gameObject); //destroying the object, once it's out of the view
            }
        }
    }
}

