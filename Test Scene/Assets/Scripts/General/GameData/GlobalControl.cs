using UnityEngine;


public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;

    // xp
    private int currentXP, nextLevelXP, previousLevelXP, playerLevel;

    // health
    private float currentHealth, maxHealth;

    // save profile
    private string saveprofilename; // default

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void SetSaveProfileName(string input) { saveprofilename = input; }
    public string GetSaveProfileName() { return saveprofilename; }

    public void SetCurrentXP(int input) { currentXP = input; }
    public int GetCurrentXP() { return currentXP; }

    public void SetNextXP(int input) { nextLevelXP = input; }
    public int GetNextXP() { return nextLevelXP; }

    public void SetPreviousXP(int input) { previousLevelXP = input; }
    public int GetPrevXP() { return previousLevelXP; }

    public void SetCurrentHealth(float input) { currentHealth = input; }
    public float GetCurrentHealth() { return currentXP; }

    public void SetMaxHealth(float input) { maxHealth = input; }
    public float GetMaxHealth() { return maxHealth; }

    public void UpdateGlobalControl()
    {
        Debug.Log("calling updateglobalcontrol with profilename: " + saveprofilename);
        Save playerData = SaveData.Load<Save>(saveprofilename);
        Debug.Log(saveprofilename + "'s player level is " + playerData._playerLevel);

        currentXP = playerData._currentXP;
        currentHealth = playerData._currentHealth;
        maxHealth = playerData._maxHealth;
        nextLevelXP = playerData._nextLevelXP;
        previousLevelXP = playerData._previousLevelXP;
        playerLevel = playerData._playerLevel;

        if (Inventory.instance)
        {
            Inventory.instance.SetInvData(playerData._itemsDict);
            Inventory.instance.UpdateKeys();
        }
    }
}