using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject player = null;

    public GameObject pauseUI = null;
    public GameObject jobChangerUI = null;
    public GameObject mainUI = null;
    public GameObject teleportUI = null;
    public GameObject optionsMenu = null;
    public GameObject controlsMenu = null;
    public GameObject[] menus = new GameObject[6];

    private void Start()
    {
        // don't include pause, controls, or options bc it can be active simultaneously w/ in game UIS
        // (jobchanger XOR mainUI XOR teleporter) AND/OR (pause XOR controls XOR options)
        menus = new GameObject[]{ jobChangerUI, mainUI, teleportUI }; 
    }

    private void Update() // check if we should open any in-game or pause UIs
    {
        if (Input.GetKeyDown(InputManager.IM.Togglespells) && !CheckMenusOpen("BookUI"))
        {
            mainUI.GetComponent<SetController>().SetCurrentSet(0);
            mainUI.SetActive(!mainUI.activeSelf);
        }
        else if (Input.GetKeyDown(InputManager.IM.Toggleinventory) && !CheckMenusOpen("BookUI"))
        { 
            mainUI.GetComponent<SetController>().SetCurrentSet(1);
            mainUI.SetActive(!mainUI.activeSelf);
        }
        else if (Input.GetKeyDown(InputManager.IM.Togglequests) && !CheckMenusOpen("BookUI"))
        {
            mainUI.GetComponent<SetController>().SetCurrentSet(2);
            mainUI.SetActive(!mainUI.activeSelf);
        }
        else if (Input.GetKeyDown(InputManager.IM.Togglemap) && !CheckMenusOpen("BookUI"))
        {
            mainUI.GetComponent<SetController>().SetCurrentSet(3);
            mainUI.SetActive(!mainUI.activeSelf);
        }
        else if (Input.GetKeyDown(InputManager.IM.Interact))
        {
            if (player.GetComponent<PlayerController>().CanOpenTeleporter && !CheckMenusOpen("TeleporterUI"))
                teleportUI.SetActive(!teleportUI.activeSelf);
            else if (player.GetComponent<PlayerController>().CanOpenJobChanger && !CheckMenusOpen("JobChangerUI"))
            {
                jobChangerUI.GetComponent<JobChange>().UpdateText();
                jobChangerUI.SetActive(!jobChangerUI.activeSelf);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape)) // manually use KeyCode.Escape, not a changeable binding
        {
            if (optionsMenu.activeSelf)
            {
                optionsMenu.SetActive(!optionsMenu.activeSelf);
                pauseUI.SetActive(true);
            }
            else if (controlsMenu.activeSelf)
            {
                controlsMenu.SetActive(!controlsMenu.activeSelf); 
                pauseUI.SetActive(true);
            }
            // account for exiting in-game menus
            else if (teleportUI.activeSelf) 
                teleportUI.SetActive(!teleportUI.activeSelf);
            else if (jobChangerUI.activeSelf)
                jobChangerUI.SetActive(!jobChangerUI.activeSelf);
            else if (mainUI.activeSelf)
                mainUI.SetActive(!mainUI.activeSelf);
            else // otherwise toggle pause menu
                pauseUI.SetActive(!pauseUI.activeSelf);
        }

        // if a UI is open and the game isn't paused, pause
        if ((pauseUI.activeSelf || mainUI.activeSelf || teleportUI.activeSelf || optionsMenu.activeSelf || controlsMenu.activeSelf) && !GameIsPaused)
            Pause();
        // if no UIs are open and the game is paused, resume
        else if (!pauseUI.activeSelf && !mainUI.activeSelf && !teleportUI.activeSelf && !optionsMenu.activeSelf && !controlsMenu.activeSelf && GameIsPaused)
            Resume();
    }

    private bool CheckMenusOpen(string ignoreUIName) // returns true if an in-game menu is open, else false
    {
        foreach (GameObject menu in menus)
        {
            if (menu.activeSelf && menu.name != ignoreUIName) // we ignore the input menu because we want to close it if it's open
                return true;
        }
        return false;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}

