using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlsMenu : MonoBehaviour
{
    Transform menuPanel;
    Event keyEvent;
    Text buttonText;
    KeyCode newKey;
    bool waitingForKey;

    void Start()
    {
        menuPanel = transform.Find("Panel");
        waitingForKey = false;

        /*iterate through child of the panel and check names */
        for (int i = 0; i < menuPanel.childCount; i++)
        {
            if (menuPanel.GetChild(i).name == "Spell1Key")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.Spell1.ToString();
            else if (menuPanel.GetChild(i).name == "Spell2Key")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.Spell2.ToString();
            else if (menuPanel.GetChild(i).name == "Spell3Key")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.Spell3.ToString();
            else if (menuPanel.GetChild(i).name == "Spell4Key")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.Spell4.ToString();
            else if (menuPanel.GetChild(i).name == "Spell5Key")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.Spell5.ToString();

            else if (menuPanel.GetChild(i).name == "ToggleSpellsKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.Togglespells.ToString();
            else if (menuPanel.GetChild(i).name == "ToggleInventoryKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.Toggleinventory.ToString();
            else if (menuPanel.GetChild(i).name == "ToggleQuestsKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.Togglequests.ToString();
            else if (menuPanel.GetChild(i).name == "ToggleMapKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.Togglemap.ToString();

            else if (menuPanel.GetChild(i).name == "InteractKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.Interact.ToString();
            else if (menuPanel.GetChild(i).name == "AddDefaultItemKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.Adddefaultitem.ToString();
            else if (menuPanel.GetChild(i).name == "AddDefaultQuestKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.Adddefaultquest.ToString();
        }

    }

    void Update()
    {
    }


    void OnGUI()
    {
        keyEvent = Event.current;
        if (keyEvent.isKey && waitingForKey)
        {
            newKey = keyEvent.keyCode; //Assigns newKey to the key user presses
            waitingForKey = false;
        }
    }


    public void StartAssignment(string keyName)
    {
        if (!waitingForKey)
            StartCoroutine(AssignKey(keyName));
    }


    public void SendText(Text text)
    {
        buttonText = text;
    }


    IEnumerator WaitForKey()
    {
        while (!keyEvent.isKey)
            yield return null;
    }


    public IEnumerator AssignKey(string keyName)
    {
        waitingForKey = true;

        yield return WaitForKey(); //Executes endlessly until user presses a key

        if (keyName == "spell1")
        {
            InputManager.IM.Spell1 = newKey; //Set spell1 to new keycode
            buttonText.text = InputManager.IM.Spell1.ToString(); //Set button text to new key
            PlayerPrefs.SetString("spell1Key", InputManager.IM.Spell1.ToString()); //save new key to PlayerPrefs
        }
        else if (keyName == "spell2")
        {
            InputManager.IM.Spell2 = newKey; //set spell2 to new keycode
            buttonText.text = InputManager.IM.Spell2.ToString(); //set button text to new key
            PlayerPrefs.SetString("spell2Key", InputManager.IM.Spell2.ToString()); //save new key to PlayerPrefs
        }
        else if (keyName == "spell3")
        {
            InputManager.IM.Spell3 = newKey; //set spell3 to new keycode    
            buttonText.text = InputManager.IM.Spell3.ToString(); //set button text to new key
            PlayerPrefs.SetString("spell3Key", InputManager.IM.Spell3.ToString()); //save new key to playerprefs
        }
        else if (keyName == "spell4")
        {
            InputManager.IM.Spell4 = newKey; //set spell4 to new keycode
            buttonText.text = InputManager.IM.Spell4.ToString(); //set button text to new key
            PlayerPrefs.SetString("spell4Key", InputManager.IM.Spell4.ToString()); //save new key to playerprefs
        }
        else if (keyName == "togglespells")
        {
            InputManager.IM.Togglespells = newKey; //set togglespells to new keycode
            buttonText.text = InputManager.IM.Togglespells.ToString(); //set button text to new key
            PlayerPrefs.SetString("togglespellsKey", InputManager.IM.Togglespells.ToString()); //save new key to playerprefs
        }
        else if (keyName == "toggleinventory")
        {
            InputManager.IM.Toggleinventory = newKey; //set toggleinventory to new keycode
            buttonText.text = InputManager.IM.Toggleinventory.ToString(); //set button text to new key
            PlayerPrefs.SetString("toggleinventoryKey", InputManager.IM.Toggleinventory.ToString()); //save new key to playerprefs
        }
        else if (keyName == "togglequests")
        {
            InputManager.IM.Togglequests = newKey; //set togglequests to new keycode
            buttonText.text = InputManager.IM.Togglequests.ToString(); //set button text to new key
            PlayerPrefs.SetString("togglequestsKey", InputManager.IM.Togglequests.ToString()); //save new key to playerprefs
        }
        else if (keyName == "togglemap")
        {
            InputManager.IM.Togglemap = newKey; //set togglemap to new keycode
            buttonText.text = InputManager.IM.Togglemap.ToString(); //set button text to new key
            PlayerPrefs.SetString("togglemapKey", InputManager.IM.Togglemap.ToString()); //save new key to playerprefs
        }
        else if (keyName == "interact")
        {
            InputManager.IM.Interact = newKey; //set interact to new keycode
            buttonText.text = InputManager.IM.Interact.ToString(); //set button text to new key
            PlayerPrefs.SetString("interactKey", InputManager.IM.Interact.ToString()); //save new key to playerprefs
        }
        else if (keyName == "adddefaultitem")
        {
            InputManager.IM.Adddefaultitem = newKey; //set adddefaultitem to new keycode
            buttonText.text = InputManager.IM.Adddefaultitem.ToString(); //set button text to new key
            PlayerPrefs.SetString("adddefaultitemKey", InputManager.IM.Adddefaultitem.ToString()); //save new key to playerprefs
        }

        else if (keyName == "adddefaultquest")
        {
            InputManager.IM.Adddefaultquest = newKey; //set adddefaultquest to new keycode
            buttonText.text = InputManager.IM.Adddefaultquest.ToString(); //set button text to new key
            PlayerPrefs.SetString("adddefaultquestKey", InputManager.IM.Adddefaultquest.ToString()); //save new key to playerprefs
        }
        yield return null;
    }

}