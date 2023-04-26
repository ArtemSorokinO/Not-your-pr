using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hearts : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Hearts;
    

    void Start()
    {
        Player.toHertsSygnal += ChangeHP;
    }


    void ChangeHP(int Heart)
    {
        int i = 0;
        foreach (var hrt in Hearts) 
        {
            if (Heart > i)
            {
                Hearts[i].gameObject.SetActive(true);
            } else
            {
                Hearts[i].gameObject.SetActive(false);
            } 
            i++;
        }
    }

    void OnDisable()
    {
        Player.toHertsSygnal -= ChangeHP;
    }
}
