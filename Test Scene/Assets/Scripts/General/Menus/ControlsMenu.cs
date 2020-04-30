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
        menuPanel = transform.Find("Columns");
        waitingForKey = false;

        // iterate through all children and set correct text for each input key
        for (int j = 0; j < menuPanel.childCount; j++)
        {
            for (int i = 0; i < menuPanel.GetChild(j).childCount; i++) // for each set of columns in columns
            {
                for (int k = 0; k < menuPanel.GetChild(j).GetChild(i).childCount; k++) // for each input in each column in columns
                {
                    Transform temp = menuPanel.GetChild(j).GetChild(i).GetChild(k);

                    if (temp.name == "InteractKey")
                        temp.GetComponentInChildren<Text>().text = InputManager.IM.Interact.ToString();   
                    else if (temp.name == "AddDefaultItemKey")
                        temp.GetComponentInChildren<Text>().text = InputManager.IM.Adddefaultitem.ToString();
                    else if (temp.name == "AddDefaultQuestKey")
                        temp.GetComponentInChildren<Text>().text = InputManager.IM.Adddefaultquest.ToString();
                    else if (temp.name == "Spell1Key")
                        temp.GetComponentInChildren<Text>().text = InputManager.IM.Spell1.ToString();
                    else if (temp.name == "Spell2Key")
                        temp.GetComponentInChildren<Text>().text = InputManager.IM.Spell2.ToString();
                    else if (temp.name == "Spell3Key")
                        temp.GetComponentInChildren<Text>().text = InputManager.IM.Spell3.ToString();
                    else if (temp.name == "Spell4Key")
                        temp.GetComponentInChildren<Text>().text = InputManager.IM.Spell4.ToString();
                    else if (temp.name == "Spell5Key")
                        temp.GetComponentInChildren<Text>().text = InputManager.IM.Spell5.ToString();
                    else if (temp.name == "ToggleSpellsKey")
                        temp.GetComponentInChildren<Text>().text = InputManager.IM.Togglespells.ToString();
                    else if (temp.name == "ToggleInventoryKey")
                        temp.GetComponentInChildren<Text>().text = InputManager.IM.Toggleinventory.ToString();
                    else if (temp.name == "ToggleQuestsKey")
                        temp.GetComponentInChildren<Text>().text = InputManager.IM.Togglequests.ToString();
                    else if (temp.name == "ToggleMapKey")
                        temp.GetComponentInChildren<Text>().text = InputManager.IM.Togglemap.ToString();  
                } // end k forloop
            } // end i forloop
        } // end j forloop

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