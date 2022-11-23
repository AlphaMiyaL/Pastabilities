using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShoot : MonoBehaviour
{
    public GameObject projectile;
    // public GameObject hitEffect;
    public Transform firepoint;
    public float speed = 20f;

    void Update()
    {
        //If left mouse button is clicked
        if(Input.GetButtonDown("Fire1"))
        {
            // call shoot function
            Shoot();
        }
    }


    void Shoot()
    {
        GameObject bullet = Instantiate(projectile, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * speed, ForceMode2D.Impulse);

    }
}
