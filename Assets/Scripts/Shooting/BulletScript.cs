using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    GameObject target;
    public float speed = 10;
    Rigidbody2D bullet;

    void Start()
    {
        bullet = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 move = (target.transform.position - transform.position).normalized * speed;
        bullet.velocity = new Vector2(move.x, move.y);
        Destroy(this.gameObject, 2);
    }
}
