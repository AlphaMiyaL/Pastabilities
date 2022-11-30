using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public int health;
    private GameObject obj;
    private int damage;

    // Start is called before the first frame update
    void Start()
    {
        damage = 1;
        obj = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
            Destroy(obj); //destroy the current object this script is attached to;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject col = other.gameObject;
        if(col.tag == "Bullet"){
            health -= damage;
            Destroy(col);

        }
        
    }

    public void IncreaseDamage(int num)
    {
        damage += num;
    }
}
