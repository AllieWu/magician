using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject mainUI = null;
    public Canvas SpellCreationUI = null;

    private void Start()
    {
        SpellCreationUI.enabled = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Toggle UI"))
        {
            mainUI.SetActive(!mainUI.activeSelf);
        }
        else if (Input.GetButtonDown("ToggleSpells"))
        {
            if (!mainUI.activeSelf)
            {
                mainUI.SetActive(true);
                mainUI.GetComponent<SetController>().SetCurrentSet(0);
            }
            else
            {
                mainUI.SetActive(false);
                mainUI.GetComponent<SetController>().SetCurrentSet(0);
            }
        }
        else if (Input.GetButtonDown("ToggleInventory"))
        {
            mainUI.SetActive(true);
            if (mainUI.GetComponent<SetController>().GetCurrentSet() != 1)
            {
                mainUI.SetActive(true);
                mainUI.GetComponent<SetController>().SetCurrentSet(1);
            }
            else
            {
                mainUI.SetActive(false);
                mainUI.GetComponent<SetController>().SetCurrentSet(0);
            }
        }
        else if (Input.GetButtonDown("ToggleQuests"))
        {
            mainUI.SetActive(true);
            if (mainUI.GetComponent<SetController>().GetCurrentSet() != 2)
            {
                mainUI.SetActive(true);
                mainUI.GetComponent<SetController>().SetCurrentSet(2);
            }
            else
            {
                mainUI.SetActive(false);
                mainUI.GetComponent<SetController>().SetCurrentSet(0);
            }
        }
        else if (Input.GetButtonDown("ToggleMap"))
        {
            mainUI.SetActive(true);
            if (mainUI.GetComponent<SetController>().GetCurrentSet() != 3)
            {
                mainUI.SetActive(true);
                mainUI.GetComponent<SetController>().SetCurrentSet(3);
            }
            else
            {
                mainUI.SetActive(false);
                mainUI.GetComponent<SetController>().SetCurrentSet(0);
            }
        }
        else if (Input.GetButtonDown("ToggleSpellCreation"))
        {
            SpellCreationUI.enabled = (!SpellCreationUI.enabled);
        }
    }
}
