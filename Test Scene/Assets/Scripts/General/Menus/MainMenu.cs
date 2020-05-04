using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject controlsMenu;
    public GameObject profilesMenu;
    public GameObject mainMenu;

    private void Start()
    {
        Debug.Log("MAIN MENU START: " + GlobalControl.Instance.GetSaveProfileName());
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

    private void UpdateProfileName(string input)
    {
        GlobalControl.Instance.SetSaveProfileName(input);

        string path = Application.persistentDataPath + "/saves/";
        string filepath = path + input + ".txt";
        if (!File.Exists(filepath)) // if the profile doesn't exist yet, create it
        {
            Debug.Log("PROFILE DIDNT EXIST, CREATING IT: " + input);
            
            Save mySave = new Save()
            {
                _currentXP = 0,
                _currentHealth = 1,
                _maxHealth = 1,
                _playerLevel = 1,
                _nextLevelXP = (int)Mathf.Floor(Mathf.Pow(1 + 10, (float)1.75)) - 30, // 1 is playerlevel
                _previousLevelXP = 0,
                _itemsDict = new Dictionary<(int, int, string, string, bool), int>()
            };
            SaveData.Save<Save>(mySave, input);
        }
    }

    public void PlayGame(string profilename)
    {
        UpdateProfileName(profilename);
        GlobalControl.Instance.UpdateGlobalControl();
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
