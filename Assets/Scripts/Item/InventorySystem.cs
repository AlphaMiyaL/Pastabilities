using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private Dictionary<ItemData, InventoryItem> _itemDict;
    public List<InventoryItem> inventory; 

    private void Awake()
    {
        inventory = new List<InventoryItem>();
        _itemDict = new Dictionary<ItemData, InventoryItem>();
    }

    public InventoryItem Get(ItemData reference)
    {
        if(_itemDict.TryGetValue(reference, out InventoryItem value))
            return value;
        return null;
    }

    public void Add(ItemData reference)
    {
        if(_itemDict.TryGetValue(reference, out InventoryItem value))
            value.AddToStack();
        else
        {
            InventoryItem temp = new InventoryItem(reference);
            inventory.Add(temp);
            _itemDict.Add(reference, temp);
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
