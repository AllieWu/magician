using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject mainUI = null;

    private void Update()
    {
        if (Input.GetButtonDown("Toggle UI"))
        {
            mainUI.SetActive(!mainUI.activeSelf);
        }
        if (Input.GetButtonDown("Inventory"))
        {
            mainUI.GetComponent<SetController>().SetCurrentSet(1);
        }
        if (Input.GetButtonDown("Quests"))
        {
            mainUI.GetComponent<SetController>().SetCurrentSet(2);
        }
    }
}
