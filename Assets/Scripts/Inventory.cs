﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Inventory
{
    public struct InventoryItem
    {
        public string item;
        public float quantity;
    }

    private List<InventoryItem> items = new List<InventoryItem>();
    
    public void AddInventory(string item, float quantity)
    {
        InventoryItem existingItem = items.FirstOrDefault(x => x.item == item);
        //check if the item already exists
        Debug.Log("Passed Item Name: " + item + " " + "Passed Item Quantity: " + quantity);
        Debug.Log("Item Name: " + existingItem.item + " " + "Item Quantity: " + existingItem.quantity);

        if (existingItem.item != null)
        {
            Debug.Log("Inside if Statement.");
            //if it exists, just add the quantity
            int index = items.FindIndex(x => x.item == item);
            InventoryItem newItem = new InventoryItem
            {
                item = existingItem.item,
                quantity = existingItem.quantity + quantity
            };
            items[index] = newItem;

        } else
        {
            InventoryItem newItem = new InventoryItem
            {
                item = item,
                quantity = quantity
            };

            items.Add(newItem);
        }
    }

    public void RemoveInventory(string item, float quantity)
    {
        InventoryItem removeItem = items.FirstOrDefault(x => x.item == item);
        int index = items.FindIndex(x => x.item == item);
        InventoryItem newItem = new InventoryItem
        {
            item = removeItem.item,
            quantity = removeItem.quantity - quantity
        };
        items[index] = newItem;
    }
    public float GetItemCount(string item)
    {
        InventoryItem itemCount = items.FirstOrDefault(x => x.item == item);
        return itemCount.quantity;
    }
}
