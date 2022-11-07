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
        health = 5;
        obj = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO : condition to damage health
        if(health <= 0){
            Destroy(obj); //destroy the current object this script is attached to;
        }
    }

}
