using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobChange : MonoBehaviour
{
    public Text JobListText;
    PlayerController playercontroller;

    public void UpdateText()
    {
        playercontroller = GameObject.Find("Player").GetComponent<PlayerController>();
        JobListText.text = "";
        foreach (BaseJob job in playercontroller.jobs)
        {
            JobListText.text += job.jobName + "\n";
        }
    }

    public void UpdatePlayer()
    {
        playercontroller.spells =  new List<string>();
        foreach (BaseJob job in playercontroller.jobs)
            playercontroller.spells.AddRange(job.spellnames); // update player's available spells

        playercontroller.UpdateHand(); // actually implements the player's hand
    }

    public void AddJob(string _jobName)
    {
        if (playercontroller.jobs.Count == 2) // maxed out at 2, must delete a job first
        {
            Debug.Log("You cannot be a " + _jobName + " since you are already: " );
            foreach (BaseJob job in playercontroller.jobs)
            {
                Debug.Log(job.jobName + "," );
            }
        }
        else if (!playercontroller.jobs.Exists(x => x.jobName == _jobName)) // if there's space and the job doesn't already exist in player's jobs, add it
        {
            Debug.Log("You have become a " + _jobName);
            BaseJob newJob;
            if (_jobName == "Wizard")    
                newJob = new Wizard();
            else if (_jobName == "Monk")
                newJob = new Monk();
            else
                newJob = new Druid();
            newJob.initialize();
            playercontroller.jobs.Add(newJob);

            UpdatePlayer(); // update the player's available spellids
        }
        UpdateText();
    }

    public void RemoveJob(string _jobName)
    {
        if (playercontroller.jobs.Exists(x => x.jobName == _jobName)) // if the job exists, delete it 
        { 
            playercontroller.jobs.Remove(playercontroller.jobs.Find(x => x.jobName == _jobName));
            Debug.Log("You quit being a " + _jobName);
        }
        else
            Debug.Log("You cannot give up the " + _jobName + " path because you never started!");
        UpdatePlayer(); // update the player's available spells
        UpdateText();
    }
}
