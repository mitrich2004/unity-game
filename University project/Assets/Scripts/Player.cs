using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    public LayerMask platformsAndGroundLayerMask;
    private bool jumpKeyWasPressed;
    private BoxCollider2D boxCollider2d;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            jumpKeyWasPressed = true;
        }
    }

    private void FixedUpdate()
    {
        if (IsGrounded() && jumpKeyWasPressed)
        {
            rb.velocity = new Vector3(0, 20, 0);
            jumpKeyWasPressed = false;
        }
    }
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, 0.1f, platformsAndGroundLayerMask);
        return raycastHit2d.collider != null;
    }

}
