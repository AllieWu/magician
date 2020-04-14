using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
    public static InputManager IM;

    //These can be accessed by any other script in our game
    // GENERAL
    public KeyCode interact { get; set; }
    
    // MOVEMENT
    public KeyCode up { get; set; } 
    public KeyCode down { get; set; }
    public KeyCode left { get; set; }
    public KeyCode right { get; set; }

    // SPELLS
    public KeyCode spell1 { get; set; }
    public KeyCode spell2 { get; set; }
    public KeyCode spell3 { get; set; }
    public KeyCode spell4 { get; set; }

    // 'CHEAT' CODES
    public KeyCode adddefaultitem { get; set; }
    public KeyCode adddefaultquest { get; set; }

    // MAIN UI
    //public KeyCode toggleui { get; set; }  <--- should be same as spells, since it's the 'first' page
    public KeyCode togglespells { get; set; }
    public KeyCode toggleinventory { get; set; }
    public KeyCode togglequests { get; set; }
    public KeyCode togglemap { get; set; }


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
        interact = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("interactKey", "F"));

        up = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("upKey", "W"));
        down = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("downKey", "S"));
        left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "A"));
        right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "D"));

        spell1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("spell1Key", "alpha1"));
        spell2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("spell2Key", "alpha2"));
        spell3 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("spell3Key", "alpha3"));
        spell4 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("spell4Key", "alpha4"));

        adddefaultitem = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("adddefaultitemKey", "equals"));
        adddefaultquest = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("adddefaultquestKey", "minus"));

        togglespells = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("togglespellsKey", "tab"));
        toggleinventory = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("toggleinventoryKey", "I"));
        togglequests = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("togglequestsKey", "Q"));
        togglemap = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("togglemapKey", "M"));


    }
}