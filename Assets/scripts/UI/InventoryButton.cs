using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    private bool isActive = true;
    [SerializeField] private GameObject prefab;
    public void Press()
    {
        isActive = !isActive;
        prefab.SetActive(isActive);
    }

    
}
