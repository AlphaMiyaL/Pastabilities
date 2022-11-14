using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public int health;
    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
            Destroy(obj); //destroy the current object this script is attached to;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject col = other.gameObject;
        if(col.tag == "Bullet"){
            health -= 1;
        }
        
    }

}
