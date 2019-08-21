using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class InventoryController : MonoBehaviour
{

    public GameObject inventoryUI;  // The entire UI
    public Image selectedItemImage;
    public Text selectedItemName;
    public Text selectedItemDesc;
    public Text selectedItemTypeID;

    Item selectedItem { get; set; }

    void Start()
    {
        UpdateDescriptionBlank();  // we start the game with an empty description box
        UpdateUI();  // load in items already in inventory

        //inventory.onItemChangedCallback += UpdateUI;
    }


    // Check to see if we should open/close the inventory
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            UpdateUI();
        }

        if (Input.GetButtonDown("AddDefaultItem"))
        {
            Inventory.instance.Add(ScriptableObject.CreateInstance<Item>());  // add in a default Item to inventory
            UpdateUI();
        }
    }


    // Update the inventory UI by:
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


    private void UpdateDescriptionBlank()
    {
        // disable icon being shown
        selectedItemImage.enabled = false;
        selectedItem = null;
        selectedItemImage.sprite = null;
        selectedItemName.text = "";
        selectedItemDesc.text = "";
        selectedItemTypeID.text = "";
    }


    public void UpdateSelectedItem(GameObject slot)
    {
        //Debug.Log("UpdateSelectedItem called " + slot.name);
        if (slot.GetComponent<SlotController>().GetItem() != null)
            UpdateDescription(true, slot.GetComponent<SlotController>().GetItem());
        else
            UpdateDescriptionBlank();
    }


}