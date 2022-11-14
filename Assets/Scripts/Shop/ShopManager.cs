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

    void Start()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanelsSO[i].SetActive(true);
        }
        cashUI.text = "Cash : " + cash.ToString();
        LoadPanels();
        CheckPurchasable();
    }

    void Update()
    {
        
    }


    public void AddCash()
    {
        cash += 100;
        cashUI.text = "Cash : " + cash.ToString();
        CheckPurchasable();
    }

    public void CheckPurchasable()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (cash >= shopItemsSO[i].price)
                myBuyBtns[i].interactable = true;
            else
                myBuyBtns[i].interactable = false;
        }
    }

    public void PurchaseItem(int btnNo)
    {
        if (cash >= shopItemsSO[btnNo].price)
        {
            cash -= shopItemsSO[btnNo].price;
            cashUI.text = "Cash : " + cash.ToString();
            CheckPurchasable();
            //unlock item
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
