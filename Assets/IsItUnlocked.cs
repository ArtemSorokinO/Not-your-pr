using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsItUnlocked : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> sprites;
    
    void Update()
    {
        foreach (var i in sprites)
        {
            if (DataHolder.characterList.Contains(i.name))
            {
                i.SetActive(true);
            } else
            {
                i.SetActive(false);
            }
        }
    }
}
