using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    public int health = 150;
        
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
            health -= 5;
        }

    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
