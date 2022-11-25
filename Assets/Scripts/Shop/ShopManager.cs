using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class ShopManager : MonoBehaviour
{
    public int cash;
    public TMP_Text cashUI;
    public ShopItem[] shopItemsSO;
    public GameObject[] shopPanelsSO;
    public ShopTemplate[] shopPanels;
    public Button[] myBuyBtns;
    private Inventory inventory;
    private GameObject player;

    public GameObject itemButton1;
    public GameObject itemButton2;




    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanelsSO[i].SetActive(true);
        }
        // cash = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().getMoney();
        cash = 100000;
        cashUI.text = "Cash : " + cash.ToString();
        LoadPanels();
        CheckPurchasable();
    }

    void Update()
    {
        
    }




    public void CheckPurchasable()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if(i == 3 || i == 4){
                bool inventoryFull = true;
                for (int j = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.isFull[j] == false)
                    {
                        inventoryFull = false;
                    }
                }
                if(inventoryFull == false){
                    myBuyBtns[i].interactable = true;

                }
            }
            if (cash >= shopItemsSO[i].price)
                myBuyBtns[i].interactable = true;
            else
                myBuyBtns[i].interactable = false;
        }
    }

    public void PurchaseItem(int btnNo)
    {
        if(btnNo == 0){
            cash -= shopItemsSO[btnNo].price;
            cashUI.text = "Cash : " + cash.ToString();
            player.GetComponent<PlayerStats>().SpendMoney(shopItemsSO[btnNo].price);
            CheckPurchasable(); // update interactable
        }
        if(btnNo == 1){
            cash -= shopItemsSO[btnNo].price;
            cashUI.text = "Cash : " + cash.ToString();
            player.GetComponent<PlayerStats>().SpendMoney(shopItemsSO[btnNo].price);
            player.GetComponent<PlayerStats>().gainMaxHealth(5);
            CheckPurchasable(); // update interactable
        }
        if(btnNo == 2){
            cash -= shopItemsSO[btnNo].price;
            cashUI.text = "Cash : " + cash.ToString();
            player.GetComponent<PlayerStats>().SpendMoney(shopItemsSO[btnNo].price);
            player.GetComponent<PlayerStats>().IncreaseHealth(10);
            CheckPurchasable(); // update interactable
        }
        if(btnNo == 3){
            PurchaseBluePotion();
            cash -= shopItemsSO[btnNo].price;
            cashUI.text = "Cash : " + cash.ToString();
            player.GetComponent<PlayerStats>().SpendMoney(shopItemsSO[btnNo].price);
            player.GetComponent<PlayerStats>().IncreaseHealth(10);
            CheckPurchasable(); // update interactable       
        }
        if(btnNo == 4){
            PurchaseOrangePotion();
            cash -= shopItemsSO[btnNo].price;
            cashUI.text = "Cash : " + cash.ToString();
            player.GetComponent<PlayerStats>().SpendMoney(shopItemsSO[btnNo].price);
            player.GetComponent<PlayerStats>().IncreaseHealth(10);
            CheckPurchasable(); // update interactable       
        }
        
        
    }

    public void PurchaseBluePotion(){
            // first check if the inventory in i slot is used or not
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    // mark slot as full
                    inventory.isFull[i] = true;

                    // add the item to the inventory
                    Instantiate(itemButton1, inventory.slots[i].transform, false);
                    i = inventory.slots.Length;

                }
            }
    }
    public void PurchaseOrangePotion(){
            // first check if the inventory in i slot is used or not
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    // mark slot as full
                    inventory.isFull[i] = true;

                    // add the item to the inventory
                    Instantiate(itemButton2, inventory.slots[i].transform, false);
                    i = inventory.slots.Length;

                }
            }
    }
    
    
    
    
    
    
    public void LoadPanels()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanels[i].titleTxt.text = shopItemsSO[i].title;
            shopPanels[i].descTxt.text = shopItemsSO[i].desc;
            shopPanels[i].priceTxt.text = shopItemsSO[i].price.ToString();
        }
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
}
