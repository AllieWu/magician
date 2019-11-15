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
        if (item != null && Inventory.instance != null)
        {
            slotIcon.sprite = item.icon;
            slotIcon.enabled = true;
        }
        else
        {
            slotIcon.sprite = Resources.Load<Sprite>("RedCircle");
            slotIcon.enabled = false;
        }
    }


    // Add item to the slot
    public void AddItem(Item newItem)
    {
        Debug.Log("Adding Item to slot with name " + newItem.Name);
        item = newItem;

        if (newItem == null)
            Debug.Log("newItem is null");
        if (newItem.icon == null)
            Debug.Log("newItem.icon is null");

        ItemContainer.GetComponent<Image>().sprite = newItem.icon;
        ItemContainer.GetComponent<Image>().enabled = true;
    }


    // Clear the slot
    public void ClearSlot()
    {
        if (item != null)
        {
            item = null;

            slotIcon.sprite = null;
            slotIcon.enabled = false;

            RemoveItemFromInventory();
        }
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