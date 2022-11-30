using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInitialize : MonoBehaviour
{
    [SerializeField] GameObject shopUI;
    public bool currentlyOpen;
    public bool inShop;
    // Start is called before the first frame update
    void Start()
    {
        currentlyOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentlyOpen ==false && inShop==true && (Input.GetKeyDown(KeyCode.E))){
            InitializeUIShop();
        }
    }
    
    void OnTriggerStay2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            inShop = true;
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            inShop = false;
        }
    }
    
    void InitializeUIShop(){
        currentlyOpen = true;
        shopUI.SetActive(true);
    }

    public void ExitShop(){
        currentlyOpen = false;
        shopUI.SetActive(false);
    }
}
