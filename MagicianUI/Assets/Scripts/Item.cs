using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
// To represent an instance of an object
// itemid (may not be necessary) - prefab item 
// name : item name
// type id: equipment (1), crafting (2), useable (3)
*/
 [ CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item") ]
public class Item : ScriptableObject
{
    // Item info
    public int ItemID { get; set; }
    public int TypeID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Sprite icon { get; set; }
    public bool showInInventory { get; set; }


    private void OnEnable()
    {
        System.Random rnd = new System.Random();
        ItemID = 0;
        TypeID = 1;
        Name = "New Item";
        Description = "This item is new. Shocking.";
        icon = (rnd.Next(0, 2) == 0) ? Resources.Load<Sprite>("RedCircle") : Resources.Load<Sprite>("BlueCircle");
        showInInventory = true;
    }


    // Called when the item is pressed in the inventory
    public virtual void Use()
    {
        Debug.Log("Item " + name + " Used");
        Debug.Log(GetItemInfo());

        // Use the item
    }


    // Call this method to remove the item from inventory
    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }


    public string GetItemInfo()
    {
        return ($"\tItem ID: {ItemID} || Name: {Name} || Type ID: {TypeID} || Description: {Description}");
    }


}