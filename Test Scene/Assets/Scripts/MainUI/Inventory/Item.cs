﻿using UnityEngine;

/*
// To represent an instance of an object
*/
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Item")]
public class Item : ScriptableObject
{
    // Item info
    public int ItemID;
    public int TypeID;
    public string Name;
    public string Description;
    public Sprite icon;
    public bool showInInventory;


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