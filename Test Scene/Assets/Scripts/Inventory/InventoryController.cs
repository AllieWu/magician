using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class InventoryController : MonoBehaviour
{

    public GameObject inventoryUI;  // The entire UI
    public GameObject descContainer;
    public GameObject removeButton;
    public GameObject selectedSlot;
    public Image selectedItemImage;
    public Text selectedItemName;
    public Text selectedItemDesc;
    public Text selectedItemTypeID;


    void Start()
    {
        UpdateUI();  // load in items already in inventory
        ToggleDescriptionAndRemoveButton(null);

        //inventory.onItemChangedCallback += UpdateUI;
    }


    // Check to see if we should open/close the inventory
    void Update()
    {
        if (Input.GetButtonDown("AddDefaultItem"))
        {
            Inventory.instance.Add(ScriptableObject.CreateInstance<Item>());  // add in a default Item to inventory
            UpdateUI();
        }
    }


    // Update the inventory UI by:;
    //		- Adding items
    //		- Clearing empty slots
    // This is called using a delegate on the Inventory.
    public void UpdateUI()
    {
        SlotController[] slots = GetComponentsInChildren<SlotController>();

        for (int i = 0; i < slots.Length; i++)
        {
            if (Inventory.instance.items.Count > 0)
            {
                if (i < Inventory.instance.items.Count)
                    slots[i].AddItem(Inventory.instance.items[i]);
                else
                    slots[i].ClearSlot();
            }
            else if (Inventory.instance.items.Count == 0)
            {
                slots[0].ClearSlot();
            }
        }
    }


    private void UpdateDescription(bool enabled, Item item)
    {
        selectedItemImage.enabled = enabled;
        selectedItemImage.sprite = item.icon;
        selectedItemName.text = item.Name;
        selectedItemDesc.text = item.Description;
        selectedItemTypeID.text = item.TypeID.ToString();
    }


    private void ToggleDescriptionAndRemoveButton(GameObject slot)
    {
        if (slot == null)  // Toggles w/o checking for items, used in Start() and when removing an item
        {
            descContainer.SetActive(!descContainer.activeSelf);
            removeButton.SetActive(!removeButton.activeSelf);
            return;
        }

        if (slot.GetComponent<SlotController>().GetItem() == null && !descContainer.activeSelf && !removeButton.activeSelf)
            return;

        descContainer.SetActive(!descContainer.activeSelf);
        removeButton.SetActive(!removeButton.activeSelf);
    }


    public void UpdateSelectedItem(GameObject slot)
    {
        selectedSlot = slot;

        if (slot.GetComponent<SlotController>().GetItem() != null)
            UpdateDescription(true, slot.GetComponent<SlotController>().GetItem());

        ToggleDescriptionAndRemoveButton(slot);
    }


    public void RemoveSelectedItem()
    {
        Debug.Log("RemoveSelectedItem called!");
        if (selectedSlot.GetComponent<SlotController>().GetItem() != null)
        {
            Debug.Log("Clicked item != null... attempting to remove!");
            Inventory.instance.Remove(selectedSlot.GetComponent<SlotController>().GetItem());
        }
        UpdateUI();
        ToggleDescriptionAndRemoveButton(null);
    }

}