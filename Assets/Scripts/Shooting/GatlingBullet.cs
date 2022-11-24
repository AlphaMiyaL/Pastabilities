using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingBullet : MonoBehaviour
{
    public int damage = 5;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Enemy enemy = collider.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.GetDamage(damage);
        }

        // destroys the bullet prefab
        Destroy(gameObject, 1f);
    }
}
