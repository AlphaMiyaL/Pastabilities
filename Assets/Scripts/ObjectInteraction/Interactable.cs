using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private bool doInteract;
    private GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        doInteract = false;        
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: condition to make doInteract 
        if(doInteract){
            //destroy the current object this script is attached to;
            Destroy(obj); 
            //condition to change something else;
        }
        
    }
}
