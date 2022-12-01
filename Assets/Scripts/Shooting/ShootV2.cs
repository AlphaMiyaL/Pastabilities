using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootV2 : MonoBehaviour
{
    public GameObject projectile;
    public Transform firepoint;
    public float speed = 20f;
    public AudioClip gunshotSFX;
    private bool cooldown = false;
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
            if (!cooldown) {
                // call shoot function
                AudioManager.instance.PlaySound(gunshotSFX);
                Shoot();
                cooldown = true;
                StartCoroutine(Cooldown());
            }
        }
    }

    private IEnumerator Cooldown() {
        yield return new WaitForSeconds(1.5f);
        cooldown = false;
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

