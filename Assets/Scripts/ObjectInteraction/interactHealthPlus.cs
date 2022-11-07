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
        //TODO: condition to make doInteract 
        if(doInteract){
            //destroy the current object this script is attached to;
            Destroy(obj); 
            //Increase health of player
        }       
    }
}
