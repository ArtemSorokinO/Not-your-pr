using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Saves : MonoBehaviour
{
    void Awake()
    {
        if (PlayerPrefs.HasKey("countOfPrays") && PlayerPrefs.HasKey("selectedCharacter") && PlayerPrefs.HasKey("avaiblePers"))
        {
            Load();
        } 
        Save();
    }

    public static void Save()
    {
        PlayerPrefs.SetInt("countOfPrays", DataHolder.countOfPrays);
        PlayerPrefs.SetInt("selectedCharacter", DataHolder.selectedCharacter);
        var avaible = "";
        foreach (var i in DataHolder.characterList)
        {
            avaible += i + " ";
        }
        avaible.Trim();
        PlayerPrefs.SetString("avaiblePers", avaible);
    }

    public static void Load()
    {
        DataHolder.countOfPrays = PlayerPrefs.GetInt("countOfPrays");
        DataHolder.selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        DataHolder.characterList = new List<string >(PlayerPrefs.GetString("avaiblePers").Split(' '));
    }
}
