using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2Zone : MonoBehaviour
{
    Animator anim;
    public bool aggro;

   [SerializeField]private GameObject movePoint1;

    [SerializeField]private GameObject movePoint2;

    [SerializeField]private GameObject movePoint3;

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

    public void OnTriggerStay2D(Collider2D col){
        if(col.CompareTag("Player")){
            aggro = true;
            anim.SetBool("PlayerNear", true);
        }
        
    }
    
    public void OnTriggerExit2D(Collider2D col){
        if(col.CompareTag("Player")){
            aggro = false;
            anim.SetBool("PlayerNear", false);
        }
        
    }

    //Teleports the bossZone and everything in it.
    public void Move(){
        GameObject t= this.gameObject;
        Vector2 movePosition;
        int ran = Random.Range(1, 4);
        if(ran == 1) movePosition = movePoint1.transform.position;
        else if(ran == 2) movePosition = movePoint2.transform.position;
        else movePosition = movePoint2.transform.position;
        if( movePosition != null) t.transform.position = movePosition;

    }
}
