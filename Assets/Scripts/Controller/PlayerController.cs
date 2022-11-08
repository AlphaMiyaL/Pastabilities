using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 15f;
    
    // to keep our 2D rigid body
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        // get the rigid body component for later use
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Handle player walking
        WalkHandler();
    }

    // Make the player walk according to use input
    void WalkHandler()
    {
        float moveLimiter = 0.7f;

        // Distance (speed = distance / time --> distance = speed * time)
        // float distance = walkSpeed * Time.deltaTime;

        // Input on x ("Horizontal")
        float hAxis = Input.GetAxisRaw("Horizontal");

        // Input on y ("Vertical")
        float vAxis = Input.GetAxisRaw("Vertical");

        // check for diagonal movement
        if (hAxis != 0 && vAxis != 0)
        {
            // limit movement by 70% speed
            hAxis *= moveLimiter;
            vAxis *= moveLimiter;
        }

        // move the rigid body
        rb.velocity = new Vector2(hAxis * walkSpeed, vAxis * walkSpeed);
    } 
}
