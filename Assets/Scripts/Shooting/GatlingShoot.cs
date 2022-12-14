using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingShoot : MonoBehaviour
{
    public GameObject projectile;
    public Transform firepoint;
    public float speed = 10f;
    public bool cooldown = false;
    public AudioClip gatlingShotSFX;

/*    private GameObject obj;*/

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
                AudioManager.instance.PlaySound(gatlingShotSFX);
                Shoot();
                cooldown = true;
                StartCoroutine(Cooldown());
            }
        }
    }

    private IEnumerator Cooldown() {
        yield return new WaitForSeconds(4f);
        cooldown = false;
    }


    void Shoot()
    {
        //Vector2 position = firepoint.up; 
        //Vector2 position2 = (position.x + 0.2f, position.y); 

        GameObject bullet = Instantiate(projectile, firepoint.position, firepoint.rotation);
        //GameObject bullet2 = Instantiate(projectile, firepoint.position, firepoint.rotation);
        //GameObject bullet3 = Instantiate(projectile, firepoint.position, firepoint.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        //Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();

        //Debug.Log(firepoint.up);
        rb.AddForce(firepoint.up * speed, ForceMode2D.Impulse);
        //rb2.AddForce(position2 * speed, ForceMode2D.Impulse);
        //rb3.AddForce(new Vector2(10, 10), ForceMode2D.Impulse);
        //rb3.AddForce(10, firepoint.up * speed, 0, ForceMode2D.Impulse);
    }

    public void IncreaseBulletSpeed(int num)
    {
        speed += num;
    }
}
