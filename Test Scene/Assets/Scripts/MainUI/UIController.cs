﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    bool GameIsPaused = false;
    public GameObject player = null;

    public GameObject pauseUI = null;
    public GameObject spellCreationUI = null;
    public GameObject mainUI = null;
    public GameObject teleportUI = null;
    public GameObject optionsMenu = null;
    public GameObject controlsMenu = null;

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetButtonDown("Toggle UI") || Input.GetButtonDown("ToggleSpells"))
        {
            mainUI.GetComponent<SetController>().SetCurrentSet(0);
            mainUI.SetActive(!mainUI.activeSelf);
        }
        else if (Input.GetButtonDown("ToggleInventory"))
        { 
            mainUI.GetComponent<SetController>().SetCurrentSet(1);
            mainUI.SetActive(!mainUI.activeSelf);
        }
        else if (Input.GetButtonDown("ToggleQuests"))
        {
            mainUI.GetComponent<SetController>().SetCurrentSet(2);
            mainUI.SetActive(!mainUI.activeSelf);
        }
        else if (Input.GetButtonDown("ToggleMap"))
        {
            mainUI.GetComponent<SetController>().SetCurrentSet(3);
            mainUI.SetActive(!mainUI.activeSelf);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            if (player.GetComponent<PlayerController>().CanOpenTeleporter)
                teleportUI.SetActive(!teleportUI.activeSelf);
            else if (player.GetComponent<PlayerController>().CanOpenSpellCreation)
                spellCreationUI.SetActive(!spellCreationUI.activeSelf);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionsMenu.activeSelf)
            {
                optionsMenu.SetActive(!optionsMenu.activeSelf);
                pauseUI.SetActive(true);

            }
            else if (controlsMenu.activeSelf)
            {
                optionsMenu.SetActive(!controlsMenu.activeSelf);
                pauseUI.SetActive(true);
            }
            else
                pauseUI.SetActive(!pauseUI.activeSelf);
        }

        // if a UI is open and the game isn't paused, pause
        if ((pauseUI.activeSelf || mainUI.activeSelf || teleportUI.activeSelf || optionsMenu.activeSelf || controlsMenu.activeSelf) && !GameIsPaused)
            Pause();
        // if no UIs are open and the game is paused, resume
        else if (!pauseUI.activeSelf && !mainUI.activeSelf && !teleportUI.activeSelf && !optionsMenu.activeSelf && !controlsMenu.activeSelf && GameIsPaused)
            Resume();
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


    /*
     
     
     using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    bool GameIsPaused = false;
    public GameObject mainUI = null;
    public GameObject spellCreationUI = null;
    public GameObject teleportUI = null;
    public GameObject player = null;

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetButtonDown("Toggle UI"))
        {
            mainUI.SetActive(!mainUI.activeSelf);
        }
        else if (Input.GetButtonDown("ToggleSpells"))
        {
            if (GameIsPaused)
            {
                Resume(mainUI);
            }
            else
            {
                Pause(mainUI);
            }
            
            if (!mainUI.activeSelf)
            {
                mainUI.SetActive(true);
                mainUI.GetComponent<SetController>().SetCurrentSet(0);
            }
            else
            {
                mainUI.SetActive(false);
                mainUI.GetComponent<SetController>().SetCurrentSet(0);
            }
        }
        else if (Input.GetButtonDown("ToggleInventory"))
        {
            mainUI.SetActive(true);
            if (mainUI.GetComponent<SetController>().GetCurrentSet() != 1)
            {
                mainUI.SetActive(true);
                mainUI.GetComponent<SetController>().SetCurrentSet(1);
            }
            else
            {
                mainUI.SetActive(false);
                mainUI.GetComponent<SetController>().SetCurrentSet(0);
            }
        }
        else if (Input.GetButtonDown("ToggleQuests"))
        {
            mainUI.SetActive(true);
            if (mainUI.GetComponent<SetController>().GetCurrentSet() != 2)
            {
                mainUI.SetActive(true);
                mainUI.GetComponent<SetController>().SetCurrentSet(2);
            }
            else
            {
                mainUI.SetActive(false);
                mainUI.GetComponent<SetController>().SetCurrentSet(0);
            }
        }
        else if (Input.GetButtonDown("ToggleMap"))
        {
            mainUI.SetActive(true);
            if (mainUI.GetComponent<SetController>().GetCurrentSet() != 3)
            {
                mainUI.SetActive(true);
                mainUI.GetComponent<SetController>().SetCurrentSet(3);
            }
            else
            {
                mainUI.SetActive(false);
                mainUI.GetComponent<SetController>().SetCurrentSet(0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            if (player.GetComponent<PlayerController>().CanOpenTeleporter)
            {
                teleportUI.SetActive(!teleportUI.activeSelf);
            }
            else if (player.GetComponent<PlayerController>().CanOpenSpellCreation)
            {
                spellCreationUI.SetActive(!spellCreationUI.activeSelf);
            }
        }
    }

    public void Resume(GameObject UI)
    {
        UI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause(GameObject UI)
    {
        UI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}

 */
  