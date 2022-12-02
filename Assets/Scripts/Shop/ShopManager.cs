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
    public AudioClip buySFX;
    private Inventory inventory;
    private GameObject player;

    public GameObject itemButton1;
    public GameObject itemButton2;

    public bool inventoryFull;




    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanelsSO[i].SetActive(true);
        }
        cash = player.GetComponent<PlayerStats>().getMoney();
        cashUI.text = "Cash : " + cash.ToString();
        LoadPanels();
        CheckPurchasable();
    }

    void Update()
    {
        CheckPurchasable();

    }


    public bool checkInventoryFull(){
        bool full = true;
        int notFull = 0;
        int size = inventory.slots.Length;
        for(int i = 0; i < size; i++){
            if(inventory.isFull[i] == false){
                notFull++;
            }
        }

        if(notFull > 0) full = false;
        return full;
    }


    public void CheckPurchasable()
    {
        cash = player.GetComponent<PlayerStats>().getMoney();    
        cashUI.text = "Cash : " + cash.ToString();
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if(i == 3 || i == 4){
                if(!checkInventoryFull() && cash >= shopItemsSO[i].price){
                    myBuyBtns[i].interactable = true;
                } else{
                    myBuyBtns[i].interactable = false;

                }
            }
            else if (cash >= shopItemsSO[i].price)
                myBuyBtns[i].interactable = true;
            else
                myBuyBtns[i].interactable = false;
        }
    }

    public void PurchaseItem(int btnNo)
    {
        if(btnNo == 0){
            // cash -= shopItemsSO[btnNo].price;
            // cashUI.text = "Cash : " + cash.ToString();
            AudioManager.instance.PlaySound(buySFX);
            player.GetComponent<PlayerStats>().SpendMoney(shopItemsSO[btnNo].price);
            // CheckPurchasable(); // update interactable
        }
        if(btnNo == 1){
            // cash -= shopItemsSO[btnNo].price;
            // cashUI.text = "Cash : " + cash.ToString();
            AudioManager.instance.PlaySound(buySFX);
            player.GetComponent<PlayerStats>().SpendMoney(shopItemsSO[btnNo].price);
            player.GetComponent<PlayerStats>().gainMaxHealth(5);
            CheckPurchasable(); // update interactable
        }
        if(btnNo == 2){
            // cash -= shopItemsSO[btnNo].price;
            // cashUI.text = "Cash : " + cash.ToString();
            AudioManager.instance.PlaySound(buySFX);
            player.GetComponent<PlayerStats>().SpendMoney(shopItemsSO[btnNo].price);
            player.GetComponent<PlayerStats>().IncreaseHealth(10);
            // CheckPurchasable(); // update interactable
        }
        if(btnNo == 3){
            PurchaseBluePotion();
            // cash -= shopItemsSO[btnNo].price;
            // cashUI.text = "Cash : " + cash.ToString();
            AudioManager.instance.PlaySound(buySFX);
            player.GetComponent<PlayerStats>().SpendMoney(shopItemsSO[btnNo].price);
            // CheckPurchasable(); // update interactable       
        }
        if(btnNo == 4){
            PurchaseOrangePotion();
            // cash -= shopItemsSO[btnNo].price;
            // cashUI.text = "Cash : " + cash.ToString();
            AudioManager.instance.PlaySound(buySFX);
            player.GetComponent<PlayerStats>().SpendMoney(shopItemsSO[btnNo].price);
            // CheckPurchasable(); // update interactable       
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
