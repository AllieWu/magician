using UnityEngine;

/* WANT TO ADD MORE CUSTOMIZABLE INPUTS?
 * 1. Add a keycode variable for it
 * 2. Give it a default binding in Awake()
 * 3. In ControlsMenu.cs, add a new else if statement in the triple for loop of Start()
 * 4. Also in ControlsMenu.cs, add a new else if statement in the AssignKey() function
 * 5. In the Unity Game Editor, Main Camera > ControlsMenu > Columns > A_Column, copy paste an input parent (has text and Key children)
        - Make sure to update the button functions in the Key child
*/
public class InputManager : MonoBehaviour
{
    public static InputManager IM;

    //These can be accessed by any other script in our game
    // GENERAL
    public KeyCode Interact { get; set; }
    
    // MOVEMENT - so far the player can't change the movement buttons, but it's set up in case we want to let them change it
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
         * their bindings are loaded next time. 
         * Default values are assigned to each Keycode via the 
         * second parameter of the GetString() function*/
        Interact = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("interactKey", "F"));

        // set up information for each profile (lvl, name, etc)
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