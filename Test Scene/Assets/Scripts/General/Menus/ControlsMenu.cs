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
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.spell1.ToString();
            else if (menuPanel.GetChild(i).name == "Spell2Key")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.spell2.ToString();
            else if (menuPanel.GetChild(i).name == "Spell3Key")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.spell3.ToString();
            else if (menuPanel.GetChild(i).name == "Spell4Key")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.spell4.ToString();

            else if (menuPanel.GetChild(i).name == "ToggleSpellsKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.togglespells.ToString();
            else if (menuPanel.GetChild(i).name == "ToggleInventoryKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.toggleinventory.ToString();
            else if (menuPanel.GetChild(i).name == "ToggleQuestsKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.togglequests.ToString();
            else if (menuPanel.GetChild(i).name == "ToggleMapKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.togglemap.ToString();

            else if (menuPanel.GetChild(i).name == "InteractKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.interact.ToString();
            else if (menuPanel.GetChild(i).name == "AddDefaultItemKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.adddefaultitem.ToString();
            else if (menuPanel.GetChild(i).name == "AddDefaultQuestKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = InputManager.IM.adddefaultquest.ToString();
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
            InputManager.IM.spell1 = newKey; //Set spell1 to new keycode
            buttonText.text = InputManager.IM.spell1.ToString(); //Set button text to new key
            PlayerPrefs.SetString("spell1Key", InputManager.IM.spell1.ToString()); //save new key to PlayerPrefs
        }
        else if (keyName == "spell2")
        {
            InputManager.IM.spell2 = newKey; //set spell2 to new keycode
            buttonText.text = InputManager.IM.spell2.ToString(); //set button text to new key
            PlayerPrefs.SetString("spell2Key", InputManager.IM.spell2.ToString()); //save new key to PlayerPrefs
        }
        else if (keyName == "spell3")
        {
            InputManager.IM.spell3 = newKey; //set spell3 to new keycode    
            buttonText.text = InputManager.IM.spell3.ToString(); //set button text to new key
            PlayerPrefs.SetString("spell3Key", InputManager.IM.spell3.ToString()); //save new key to playerprefs
        }
        else if (keyName == "spell4")
        {
            InputManager.IM.spell4 = newKey; //set spell4 to new keycode
            buttonText.text = InputManager.IM.spell4.ToString(); //set button text to new key
            PlayerPrefs.SetString("spell4Key", InputManager.IM.spell4.ToString()); //save new key to playerprefs
        }
        else if (keyName == "togglespells")
        {
            InputManager.IM.togglespells = newKey; //set togglespells to new keycode
            buttonText.text = InputManager.IM.togglespells.ToString(); //set button text to new key
            PlayerPrefs.SetString("togglespellsKey", InputManager.IM.togglespells.ToString()); //save new key to playerprefs
        }
        else if (keyName == "toggleinventory")
        {
            InputManager.IM.toggleinventory = newKey; //set toggleinventory to new keycode
            buttonText.text = InputManager.IM.toggleinventory.ToString(); //set button text to new key
            PlayerPrefs.SetString("toggleinventoryKey", InputManager.IM.toggleinventory.ToString()); //save new key to playerprefs
        }
        else if (keyName == "togglequests")
        {
            InputManager.IM.togglequests = newKey; //set togglequests to new keycode
            buttonText.text = InputManager.IM.togglequests.ToString(); //set button text to new key
            PlayerPrefs.SetString("togglequestsKey", InputManager.IM.togglequests.ToString()); //save new key to playerprefs
        }
        else if (keyName == "togglemap")
        {
            InputManager.IM.togglemap = newKey; //set togglemap to new keycode
            buttonText.text = InputManager.IM.togglemap.ToString(); //set button text to new key
            PlayerPrefs.SetString("togglemapKey", InputManager.IM.togglemap.ToString()); //save new key to playerprefs
        }
        else if (keyName == "interact")
        {
            InputManager.IM.interact = newKey; //set interact to new keycode
            buttonText.text = InputManager.IM.interact.ToString(); //set button text to new key
            PlayerPrefs.SetString("interactKey", InputManager.IM.interact.ToString()); //save new key to playerprefs
        }
        else if (keyName == "adddefaultitem")
        {
            InputManager.IM.adddefaultitem = newKey; //set adddefaultitem to new keycode
            buttonText.text = InputManager.IM.adddefaultitem.ToString(); //set button text to new key
            PlayerPrefs.SetString("adddefaultitemKey", InputManager.IM.adddefaultitem.ToString()); //save new key to playerprefs
        }

        else if (keyName == "adddefaultquest")
        {
            InputManager.IM.adddefaultquest = newKey; //set adddefaultquest to new keycode
            buttonText.text = InputManager.IM.adddefaultquest.ToString(); //set button text to new key
            PlayerPrefs.SetString("adddefaultquestKey", InputManager.IM.adddefaultquest.ToString()); //save new key to playerprefs
        }
        yield return null;
    }

}