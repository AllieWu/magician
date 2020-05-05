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
    private string saveprofilename;

    private void Start() { }
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

    public void PlayGame(string profilename)
    {
        saveprofilename = profilename;
        PlayerPrefs.SetString("profile", saveprofilename);
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
