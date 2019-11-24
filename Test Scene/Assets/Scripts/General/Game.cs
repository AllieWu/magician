using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System;
using System.Runtime.Serialization;
using System.Reflection;

public class Game : MonoBehaviour
{
    private Save CreateSaveGameObject()
    {
        Save save = new Save();
        PlayerController player = GetComponent<UIController>().player.GetComponent<PlayerController>();

        save.maxHealth = player.maxHealth;
        save.currentHealth = player.currentHealth;
        save.playerLevel = player.playerLevel;
        save.currentXP = player.currentXP;
        save.nextLevelXP = player.currentXP;
        save.previousLevelXP = player.previousLevelXP;
        save.itemsDict = Inventory.instance.itemsDict;
        save.keys = Inventory.instance.keys;

        return save;
    }

    public void SaveGame(string filePath = "Saves/1.txt")
    {
        // 1
        Save save = CreateSaveGameObject();

        // 2
        Stream stream = File.Open(Directory.GetCurrentDirectory()+filePath, FileMode.Create);
        BinaryFormatter bformatter = new BinaryFormatter();
        bformatter.Binder = new VersionDeserializationBinder();
        bformatter.Serialize(stream, save);
        stream.Close();
    }

    public void LoadGame(string filePath = "Saves/1.txt")
    {
        Save save = new Save();
        Stream stream = File.Open(Directory.GetCurrentDirectory()+filePath, FileMode.Open);
        BinaryFormatter bformatter = new BinaryFormatter();
        bformatter.Binder = new VersionDeserializationBinder();
        save = (Save)bformatter.Deserialize(stream);
        stream.Close();

        PlayerController player = GetComponent<UIController>().player.GetComponent<PlayerController>();
        player.currentXP = save.currentXP;
        player.nextLevelXP = save.nextLevelXP;
        player.previousLevelXP = save.previousLevelXP;
        player.playerLevel = save.playerLevel;
        player.maxHealth = save.maxHealth;
        player.currentXP = save.currentXP;
        Inventory.instance.itemsDict = save.itemsDict;
        Inventory.instance.keys = save.keys;

        Debug.Log("Game Loaded");
    }
}

public sealed class VersionDeserializationBinder : SerializationBinder
{
    public override Type BindToType(string assemblyName, string typeName)
    {
        if (!string.IsNullOrEmpty(assemblyName) && !string.IsNullOrEmpty(typeName))
        {
            Type typeToDeserialize = null;

            assemblyName = Assembly.GetExecutingAssembly().FullName;

            // The following line of code returns the type. 
            typeToDeserialize = Type.GetType(String.Format("{0}, {1}", typeName, assemblyName));

            return typeToDeserialize;
        }

        return null;
    }
}