using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class praysCountGacha : MonoBehaviour
{
    [SerializeField]
    private Text praysText;
    [SerializeField]
    private Animator anim0;
    [SerializeField]
    private Animator anim1;
    [SerializeField]
    private Animator anim2;
    [SerializeField]
    private Animator anim3;


    void Update()
    {
        praysText.text = DataHolder.countOfPrays.ToString();
    }

    public void SetHero0()
    {
        DataHolder.selectedCharacter = 0;
        anim0.SetTrigger("choose");
    }
    public void SetHero1()
    {
        DataHolder.selectedCharacter = 1;
        anim1.SetTrigger("choose");
    }
    public void SetHero2()
    {
        DataHolder.selectedCharacter = 2;
        anim2.SetTrigger("choose");
    }
    public void SetHero3()
    {
        DataHolder.selectedCharacter = 3;
        anim3.SetTrigger("choose");
    }
}
