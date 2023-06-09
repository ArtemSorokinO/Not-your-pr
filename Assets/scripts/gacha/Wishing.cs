using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Wishing : MonoBehaviour
{
    [SerializeField]
    private GameObject anim;
    [SerializeField]
    private List<GameObject> buttons;



    
    public void Wish()
    {
        if (DataHolder.countOfPrays > 0)
        {
            DataHolder.countOfPrays--;
            anim.SetActive(true);
            foreach (GameObject i in buttons)
            {
                i.SetActive(false);
            }
            Invoke("onWished", 5.5f);
        }
    }


    public void onWished()
    {
        var rand = UnityEngine.Random.Range(0, 101);
        Debug.Log(rand.ToString());
        if (rand < 51)
        {
            
        }
        else if (rand < 81)
        {
            if (!DataHolder.characterList.Contains("flameKnight")) DataHolder.characterList.Add("flameKnight");
        }
        else if (rand < 96)
        {
            if (!DataHolder.characterList.Contains("chainsaw")) DataHolder.characterList.Add("chainsaw");
        }
        else 
        {
            if (!DataHolder.characterList.Contains("mage")) DataHolder.characterList.Add("mage");
        }
        anim.SetActive(false);
        foreach (GameObject i in buttons)
        {
            i.SetActive(true);
        }
    }
}
