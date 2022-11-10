using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;

    private void Start()
    {
        // inventory companent that is attached to the tag component "Player"
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // collect the item when the player touches it
    private void OnTriggerEnter2D(Collider2D coll)
    {
        // if the "Player" touches it, the item will be added to the inventory
        if (coll.CompareTag("Player"))
        {
            // first check if the inventory in i slot is used or not
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    // mark slot as full
                    inventory.isFull[i] = true;

                    // add the item to the inventory
                    Instantiate(itemButton, inventory.slots[i].transform, false);

                    // remove the item after it is being picked
                    Destroy(gameObject);
                    break;
                }
            }

        }
    }
}
