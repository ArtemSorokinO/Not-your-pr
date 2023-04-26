using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CharacterGenerator : MonoBehaviour
{
    
    public List<GameObject> charactersList = new List<GameObject>();

    void Start()
    {
        
        

        foreach (GameObject i in charactersList)
        {
            if (i.GetComponent<Player>() != null && DataHolder.characterList.Contains(i.name))
            {
                if (i.GetComponent<Player>().id == DataHolder.selectedCharacter)
                {
                    Debug.Log(i.name);
                    var play = Instantiate(i, Vector3.zero, Quaternion.identity);
                    break;
                }
            }
        }
    }
}
