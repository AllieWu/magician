using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SlotController : MonoBehaviour
{

    Image slotIcon;  // holds image object of ItemContainer (change .sprite to change icon sprite!)
    public GameObject ItemContainer;
    public Item item;  // Current item in the slot


    private void Start()
    {
        slotIcon = ItemContainer.GetComponent<Image>();

        // If pre-determined held item, initalize icon at start, add to inv
        if (item != null && Inventory.instance != null)  // inventory IS NULL FOR SOME REASON?!
        {
            slotIcon.sprite = item.icon;
            slotIcon.enabled = true;
            //Inventory.instance.Add(item);
        }
    }


    // Add item to the slot
    public void AddItem(Item newItem)
    {
        item = newItem;

        if (slotIcon == null)
            Debug.Log("icon is null");
        if (slotIcon.sprite == null)
            Debug.Log("icon.sprite is null");
        if (item == null)
            Debug.Log("item is null");
        if (item.icon == null)
            Debug.Log("item.icon is null");

        slotIcon.sprite = item.icon;
        slotIcon.enabled = true;
    }


    // Clear the slot
    public void ClearSlot()
    {
        item = null;

        slotIcon.sprite = null;
        slotIcon.enabled = false;

        RemoveItemFromInventory();
    }


    // If the remove button is pressed, this function will be called.
    public void RemoveItemFromInventory()
    {
        Inventory.instance.Remove(item);
    }


    // Use the item
    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }


    public Item GetItem()
    {
        return item;
    }

}