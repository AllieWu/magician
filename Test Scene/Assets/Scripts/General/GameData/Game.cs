using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization;
using System.Reflection;

public class Game : MonoBehaviour
{
   
    /*
    private Dictionary<(int,int,string,string,bool),int> ExpandItemsDict(Dictionary<Item, int> input)
    {
        Dictionary<(int, int, string, string, bool), int> output = new Dictionary<(int, int, string, string, bool), int>();

        foreach (var item in input)
        {
            output.Add((item.Key.ItemID,item.Key.TypeID,item.Key.Name,item.Key.Description,item.Key.showInInventory),item.Value);
        }
        return output;
    }

    private List<(int,int,string,string,bool)> GetExpandedItemsDictKeys(List<Item> input)
    {
        List<(int, int, string, string, bool)> output = new List<(int, int, string, string, bool)>();

        foreach (var item in input)
        {
            output.Add((item.ItemID, item.TypeID, item.Name, item.Description, item.showInInventory));
        }
        return output;
    }

    private Dictionary<Item, int> CompressItemsDict (Dictionary<(int, int, string, string, bool), int> input)
    {
        Dictionary<Item, int> output = new Dictionary<Item, int>();

        foreach (var item in input)
        {
            output.Add(new Item(item.Key), item.Value);
        }
        return output;
    }

    private List<Item> GetCompressedItemDictKeys(List<(int, int, string, string, bool)> input)
    {
        List<Item> output = new List<Item>();

        foreach (var item in input)
        {
            output.Add(new Item(item));
        }
        return output;
    }
    

    private Save CreateSaveGameObject()
    {
        Save save = new Save();
        PlayerController player = GetComponent<UIController>().player.GetComponent<PlayerController>();

        // player 
        save.maxHealth = player.maxHealth;
        save.currentHealth = player.currentHealth;
        save.playerLevel = player.playerLevel;
        save.currentXP = player.currentXP;
        save.nextLevelXP = player.currentXP;
        save.previousLevelXP = player.previousLevelXP;

        save.inv = Inventory.instance;
        //save.itemsDict = ExpandItemsDict(Inventory.instance.itemsDict);
        //save.keys = GetExpandedItemsDictKeys(Inventory.instance.keys);

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
        stream.Position = 0;
        bformatter.Serialize(stream, save);
        stream.Close();
    }

    public void LoadGame(string filePath = "Saves/1.txt")
    {
        Save save = new Save();
        Stream stream = File.Open(Directory.GetCurrentDirectory()+filePath, FileMode.Open);
        stream.Position = 0;

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

        Inventory.instance = save.inv;

        //Inventory.instance.itemsDict = CompressItemsDict(save.itemsDict);
        //Inventory.instance.keys = GetCompressedItemDictKeys(save.keys);

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
    */
}