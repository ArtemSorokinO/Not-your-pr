using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGenerator : MonoBehaviour
{
    private int id = DataHolder.selectedCharacter;
    [SerializeField]
    private GameObject fastAttackButton;
    [SerializeField]
    private GameObject heavyAttackButton;

    [SerializeField]
    private Sprite spriteFastId1;
    [SerializeField]
    private Sprite spriteFastId2;
    [SerializeField]
    private Sprite spriteHeavyId2;
    

    void Start()
    {
        
        if (id == 2)
        {
            heavyAttackButton.SetActive(false);
            fastAttackButton.GetComponent<Image>().sprite = spriteFastId1;
        } else if (id == 3) 
        {
            fastAttackButton.GetComponent<Image>().sprite = spriteFastId2;
            heavyAttackButton.GetComponent<Image>().sprite = spriteHeavyId2;
        }
    }
}
