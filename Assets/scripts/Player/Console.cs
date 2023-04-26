using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Console : MonoBehaviour
{
    private List<string> cheats = new List<string> {
        "WhosYourDaddy", //invinsible 
        "LeafitToMe", //points
        "GreedIsGood", //prays
        "ISeeDeadPeople" //characters
        };
    [SerializeField]
    private InputField console;
    public static Action<int> praysChange;


    public void Cheat()
    {
        var cons = console.text;
        if (cons.Contains(cheats[0] + " true")) {

            GameObject.FindWithTag("Player").GetComponent<Player>().SetInvinceble();
            console.text = "";

        } else if (cons.Contains(cheats[0] + " false"))
        {

            GameObject.FindWithTag("Player").GetComponent<Player>().SetVinceble();
            console.text = "";

        } else if (cons.Contains(cheats[1]))
        {

            var count = int.Parse(cons.Split(" ")[1]);
            console.text = "";

        } else if (cons.Contains(cheats[2]))
        {

            var count = int.Parse(cons.Split(" ")[1]);
            DataHolder.countOfPrays += count;
            praysChange?.Invoke(DataHolder.countOfPrays);
            console.text = "";

        } else if (cons.Contains(cheats[3]))
        {

            DataHolder.characterList = new List<string> { "knight", "flameKnight", "chainsaw", "mage" };
            console.text = "";

        }

    }
}
