using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 3;
    public GameObject bulletEffect;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Enemy enemy = collider.GetComponent<Enemy>();

        if(enemy != null)
        {
            enemy.GetDamage(damage);
            // bullet effect
            GameObject effect = Instantiate(bulletEffect, transform.position, Quaternion.identity);

            // bullet effect dissappears after 0.5 second.
            Destroy(effect, 0.05f);

            // destroys the bullet prefab
            Destroy(gameObject);
            PointController point = GameObject.FindGameObjectWithTag("Points").GetComponent<PointController>();
            point.points += 10;
        }
    }
}
