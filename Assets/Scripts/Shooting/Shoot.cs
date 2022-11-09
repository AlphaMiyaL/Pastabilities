using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Rigidbody projectile;
    public float speed = 20;

    void Update()
    {
        //If left mouse button is clicked
        if(Input.GetMouseButton(0))
        {
            Rigidbody instProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;

            //Object move
            instProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));


        }
    }
}
