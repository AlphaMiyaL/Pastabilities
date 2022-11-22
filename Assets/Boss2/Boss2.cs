using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    GameObject zone;
    public int health;
    private Animator anim;
    public bool aggressive;
    // Start is called before the first frame update
    void Start()
    {
        aggressive = false;
        health = 300;
        zone = GameObject.Find("Boss2Zone");
    }

    // Update is called once per frame
    void Update()
    {
        aggressive = zone.GetComponent<B2Zone>().aggro;
        if(health < 0){
                Die();
        }
        if(aggressive){
            Attack();

        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D other){
        GameObject col = other.gameObject;
        if(col.tag == "Bullet"){
            health -= 2;
        }

    }
    private void Die(){
        Destroy(gameObject);
    }

    private void Attack(){
        //TODO
    }

}

