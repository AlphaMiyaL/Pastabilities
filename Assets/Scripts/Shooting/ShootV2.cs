using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootV2 : MonoBehaviour
{
    public GameObject projectile;
    public float speed = 20;

    void Update()
    {
        LookAtMouse();
        //If left mouse button is clicked
        if(Input.GetMouseButton(0))
        {
            GameObject instProjectile = Instantiate(projectile, transform.position, transform.rotation);

            Rigidbody2D proj = instProjectile.GetComponent<Rigidbody2D>();

            //Object move
            proj.velocity = transform.TransformDirection(new Vector3(0, 0, speed));

            //Destroy the projectile after 3 seconds
            Destroy(instProjectile, 3);


        }
    }
    private void LookAtMouse()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = mousePos;
    }
}

