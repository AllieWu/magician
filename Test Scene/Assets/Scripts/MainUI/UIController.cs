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
            else if (player.GetComponent<PlayerController>().CanOpenJobChanger)
            {
                jobChangerUI.GetComponent<JobChange>().UpdateText();
                jobChangerUI.SetActive(!jobChangerUI.activeSelf);
            }
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

