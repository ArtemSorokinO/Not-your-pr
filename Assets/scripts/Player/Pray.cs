using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Pray : MonoBehaviour
{
    public static Action<int> praysChange;

    [SerializeField]
    private GameObject obj;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            DataHolder.countOfPrays++;
            Destroy(obj);
            praysChange?.Invoke(DataHolder.countOfPrays);
        }
        
    }

}
