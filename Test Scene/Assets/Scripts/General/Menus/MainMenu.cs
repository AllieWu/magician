using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject controlsMenu;
    public GameObject profilesMenu;
    Transform profiles;
    public GameObject mainMenu;

    private void Start() 
    {
    }
    
    private void Update() // check for esc to exit UIs
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (optionsMenu.activeSelf)
            {
                optionsMenu.SetActive(!optionsMenu.activeSelf);
                mainMenu.SetActive(true);
            }
            else if (controlsMenu.activeSelf)
            {
                controlsMenu.SetActive(!controlsMenu.activeSelf);
                mainMenu.SetActive(true);
            }
            else if (profilesMenu.activeSelf)
            {
                profilesMenu.SetActive(!profilesMenu.activeSelf);
                mainMenu.SetActive(true);
            }
            else if (mainMenu.activeSelf)
                mainMenu.SetActive(!mainMenu.activeSelf);
        }
    }

    public void UpdateProfiles() // set up information for each profile (lvl, name, etc)
    {
        foreach (Transform prof in profilesMenu.transform.Find("Panel").Find("ProfilesParent"))
        {
            if (!prof) break; // if the profile doesn't exist break out
            foreach (Transform text in prof)
            {
                string file = Application.persistentDataPath + "/saves/save" + prof.name[prof.name.Length - 1] + ".txt";
                if (!File.Exists(file)) return; // if this save doesn't exist, just return

                Save playerData = SaveData.Load<Save>("save" + prof.name[prof.name.Length - 1]); // load in the info from save

                if (text.name == "Name")
                    text.GetComponentInChildren<Text>().text = "BOB"; // default
                else if (text.name == "Lvl")
                    text.GetComponentInChildren<Text>().text = playerData._playerLevel.ToString();
                else if (text.name == "Class")
                    text.GetComponentInChildren<Text>().text = "WIZ"; // default
                else if (text.name == "Location")
                    text.GetComponentInChildren<Text>().text = "STARTING TOWN"; // default
            }
        }

        /*
        profiles = transform.parent..parent.Find("Canvas").Find("ProfilesMenu").Find("Panel").Find("ProfilesParent");

        if (!profiles) return; // if we couldn't find ProfilesParent, just exit

        for (int i = 0; i < profiles.childCount; i++) // for each profile
        {
            string file = Application.persistentDataPath + "/saves/save" + profiles.GetChild(i).name[-1] + ".txt";
            if (File.Exists(file)) // we only continue if the save data exists for this save slot
            {
                Debug.Log("File at: " + file + " Exists");
                // load file info
                Save playerData = SaveData.Load<Save>("save" + profiles.GetChild(i).name[-1]);

                for (int j = 0; j < profiles.GetChild(i).childCount; j++) // fill each text child in each valid profile
                {
                    Transform temp = profiles.GetChild(i).GetChild(j);
                    if (temp.name == "Name")
                        ;
                    else if (temp.name == "Lvl")
                        temp.GetComponent<Text>().text = playerData._playerLevel.ToString();
                    else if (temp.name == "Class")
                        ;
                    else if (temp.name == "Location")
                        ;
                }
            }
        }
        */
    }
    public void PlayGame(string profilename) // set up save profile to use and start game
    {
        PlayerPrefs.SetString("profile", profilename);
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame() // quit application
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
