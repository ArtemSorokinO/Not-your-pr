using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteRandom : MonoBehaviour
{
    public Sprite[] Pikch;
    private int rand;
    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(0, Pikch.Length);
        GetComponent<SpriteRenderer>().sprite = Pikch[rand];
    }

    // Update is called once per frame
     
}
