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
            if (!prof) break;// if the profile, just return
            
            foreach (Transform text in prof) // if profile exists
            {
                string file = Application.persistentDataPath + "/saves/save" + prof.name[prof.name.Length - 1] + ".txt";
                if (!File.Exists(file)) // if this save doesn't exist, show that to the user
                {
                    if (text.name == "Name")
                        text.GetComponentInChildren<Text>().text = "EMPTY SAVE";
                    else if (text.name == "Lvl")
                        text.GetComponentInChildren<Text>().text = "";
                    else if (text.name == "Class")
                        text.GetComponentInChildren<Text>().text = ""; 
                    else if (text.name == "Location")
                        text.GetComponentInChildren<Text>().text = "";
                }
                else
                {
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
        }
    }

    public void DeleteProfile(int n){
        string file = Application.persistentDataPath + "/saves/save" + n.ToString() + ".txt";
        if (File.Exists(file)) // if file exists, delete - otherwise return
            File.Delete(file);
        UpdateProfiles();
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
