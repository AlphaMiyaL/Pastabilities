using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootV2 : MonoBehaviour
{
    public GameObject projectile;
    public Transform firepoint;
    public float speed = 20f;
/*
    private GameObject obj;*/

    //void Start()
    //{
    //    obj = this.gameObject;
    //}

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
    public void IncreaseBulletSpeed(int num)
    {
        speed += num;
    }
}

