using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // check whether the slot in the inventory is full
    public bool[] isFull;

    // slots in the inventory
    public GameObject[] slots; 

    private Dictonary<ItemData, InventoryItem> _itemDict;
    public List<InventoryItem> inventory {get; private set;}

    public void Awake()
    {
        inventory = new List<InventoryItem>();
        _itemDict = new Dictonary<ItemData, InventoryItem>();
    }

    public InventoryItem Get(ItemData reference)
    {
        if(_itemDict.TryGetValue(reference, out InventoryItem value))
        {
            return value;
        }
        return null;
    }

    public void Add(ItemData reference)
    {
        if(_itemDict.TryGetValue(reference, out InventoryItem value))
        {
            value.AddToStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(reference);
            inventory.Add(newItem);
            _itemDict.Add(reference, newItem);
        }
    }

    public void Remove(ItemData reference)
    {
        if(_itemDict.TryGetValue(reference, out InventoryItem value))
        {
            value.RemoveFromStack();

            if(value.stackSize == 0)
            {
                inventory.Remove(value);
                _itemDict.Remove(reference);
            }
        }
    }
}
