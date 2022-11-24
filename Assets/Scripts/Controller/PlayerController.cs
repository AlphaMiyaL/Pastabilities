using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 3f;
    
    // to keep our 2D rigid body
    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePosition;

    // Update is called once per frame
    void Update()
    {
        // Input on x ("Horizontal")
        movement.x = Input.GetAxisRaw("Horizontal");

        // Input on y ("Vertical")
        movement.y = Input.GetAxisRaw("Vertical");

        // current position of the mouse
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        // move the rigid body
        rb.MovePosition(rb.position + movement * walkSpeed * Time.fixedDeltaTime);

        // the position the mouse will be looking
        Vector2 lookDirection = mousePosition - rb.position;

        // the angle where the player will be looking at
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        // apply the angle to the player
        rb.rotation = angle;
    }

    public void IncreaseWalkSpeed(int num)
    {
        walkSpeed += num;
    }

    //void OnTriggerEnter2d(Collider collider)
    
}
