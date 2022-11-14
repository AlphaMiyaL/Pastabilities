using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopMenu", menuName = "Scriptable objects/new shop item", order = 1)]
public class ShopItem : ScriptableObject
{
    public string title;
    public string desc;
    public int price;
}
