using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
    public static InputManager IM;

    //These can be accessed by any other script in our game
    // GENERAL
    public KeyCode Interact { get; set; }
    
    // MOVEMENT
    public KeyCode Up { get; set; } 
    public KeyCode Down { get; set; }
    public KeyCode Left { get; set; }
    public KeyCode Right { get; set; }

    // SPELLS
    public KeyCode Spell1 { get; set; }
    public KeyCode Spell2 { get; set; }
    public KeyCode Spell3 { get; set; }
    public KeyCode Spell4 { get; set; }
    public KeyCode Spell5 { get; set; }

    // 'CHEAT' CODES
    public KeyCode Adddefaultitem { get; set; }
    public KeyCode Adddefaultquest { get; set; }

    // MAIN UI
    //public KeyCode Toggleui { get; set; }  <--- should be same as spells, since it's the 'first' page
    public KeyCode Togglespells { get; set; }
    public KeyCode Toggleinventory { get; set; }
    public KeyCode Togglequests { get; set; }
    public KeyCode Togglemap { get; set; }


    void Awake()
    {
        //Singleton pattern
        if (IM == null)
        {
            DontDestroyOnLoad(gameObject);
            IM = this;
        }
        else if (IM != this)
        {
            Destroy(gameObject);
        }
        /*Assign each keycode when the game starts.
         * Loads data from PlayerPrefs so if a user quits the game,
         * their bindings are loaded next time. Default values
         * are assigned to each Keycode via the second parameter
         * of the GetString() function*/
        Interact = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("interactKey", "F"));

        Up = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("upKey", "W"));
        Down = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("downKey", "S"));
        Left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "A"));
        Right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "D"));

        Spell1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("spell1Key", "Alpha1"));
        Spell2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("spell2Key", "Alpha2"));
        Spell3 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("spell3Key", "Alpha3"));
        Spell4 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("spell4Key", "Alpha4"));
        Spell5 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("spell5Key", "Alpha5"));

        Adddefaultitem = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("adddefaultitemKey", "Equals"));
        Adddefaultquest = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("adddefaultquestKey", "Minus"));

        Togglespells = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("togglespellsKey", "Tab"));
        Toggleinventory = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("toggleinventoryKey", "I"));
        Togglequests = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("togglequestsKey", "Q"));
        Togglemap = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("togglemapKey", "M"));


    }
}