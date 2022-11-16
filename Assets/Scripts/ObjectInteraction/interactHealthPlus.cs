using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactHealthPlus : MonoBehaviour
{
    private bool doInteract;
    private GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        doInteract = false;
        obj = this.gameObject;
        //health = get health from health script        
    }

    // Update is called once per frame
    void Update()
    {
        if(doInteract){
            //destroy the current object this script is attached to;
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerStats stats = player.GetComponent<PlayerStats>();
            stats.IncreaseHealth(6);
            Destroy(obj); 
            //TODO: Increase health of player
        }       
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject col = other.gameObject;
        if(col.tag == "Player"){
            doInteract = true;
        }
        
    }
}
