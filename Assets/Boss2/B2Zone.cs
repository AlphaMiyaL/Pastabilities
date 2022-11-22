using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2Zone : MonoBehaviour
{
    Animator anim;
    public bool aggro;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        aggro = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D col){
        aggro = true;
        anim.SetBool("PlayerNear", true);
    }
    public void OnTriggerExit2D(Collider2D col){
        aggro = false;
        anim.SetBool("PlayerNear", false);
    }
}
