using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicForBoss : MonoBehaviour
{
    void Awake()
    {
        GameObject.FindGameObjectWithTag("LevelMusic").SetActive(false);
    }
}
