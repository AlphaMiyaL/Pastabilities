using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    public int health = 150;

    public GameObject stairs;
    private GameObject obj;
    private int damage = 5;

    void Start()
    {
        obj = this.gameObject;
    }

    void Update()
    {
        if(health < 0){
            Die();
        }

    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        GameObject col = collider.gameObject;
        if(col.tag == "Bullet"){
            health -= damage;
        }

    }

    public void IncreaseDamage(int num)
    {
        damage += num;
    }

    private void Die()
    {
        PointController point = GameObject.FindGameObjectWithTag("Points").GetComponent<PointController>();
        point.points += 5000;

        Vector2 t = gameObject.transform.position;
        Instantiate(stairs, t, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
