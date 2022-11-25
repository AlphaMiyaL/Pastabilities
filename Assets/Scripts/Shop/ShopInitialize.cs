using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInitialize : MonoBehaviour
{
    [SerializeField] GameObject shopUI;
    public bool ableToRunShop;
    // Start is called before the first frame update
    void Start()
    {
        ableToRunShop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(ableToRunShop && (Input.GetKeyDown(KeyCode.E))){
            InitializeUIShop();
        }
    }
    
    void OnTriggerStay2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            ableToRunShop = true;
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            ableToRunShop = false;
        }
    }
    
    void InitializeUIShop(){
        Time.timeScale = 0;
        shopUI.SetActive(true);
    }

    public void ExitShop(){
        Time.timeScale = 1;
        shopUI.SetActive(false);
    }
}
