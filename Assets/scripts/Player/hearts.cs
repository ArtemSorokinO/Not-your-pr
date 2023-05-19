using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class hearts : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Hearts = new List<GameObject>();
    [SerializeField]
    private List<GameObject> emptyHearts = new List<GameObject>();

    private int maxMaxPlayerHP = 10;



    void Awake()
    {
        SetHP(10);
        Player.toHertsSygnalSet += SetHP;
        Player.toHertsSygnal += ChangeHP;
        Player.toHertsSygnalArmor += ChangeArmor;
        
    }

    void OnDisable()
    {
        Player.toHertsSygnalSet -= SetHP;
        Player.toHertsSygnal -= ChangeHP;
        Player.toHertsSygnalArmor -= ChangeArmor;
    }

    void SetHP(int hp)
    {
        int i = 0;
        foreach (var hrt in emptyHearts)
        {
            if (hp > i)
            {
                // эта шл€па null
                
                hrt.SetActive(true);
            }
            else
            {
                hrt.SetActive(false);
            }
            i++;
        }
    }


    void ChangeHP(int Heart)
    {
        if (Heart <= maxMaxPlayerHP)
        {
            int i = 0;
            foreach (var hrt in Hearts)
            {
                if (Heart > i)
                {
                    hrt.SetActive(true);
                }
                else
                {
                    hrt.SetActive(false);
                }
                i++;
            }
        }
    }

    void ChangeArmor(int armor)
    {
        int i = 0;
        foreach (var hrt in Hearts)
        {
            if (armor > i)
            {
                Hearts[i].gameObject.GetComponent<Image>().color = new Color(0, 0.7362874f, 1);
            }
            else
            {
                Hearts[i].gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
            }
            i++;
        }
    }
}
