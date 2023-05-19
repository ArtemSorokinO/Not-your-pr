using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField] private Enemy boss;
    [SerializeField] private GameObject firstStage;
    [SerializeField] private GameObject secondStage;

    void Awake()
    {
        firstStage.SetActive(true);
    }

    public void UpdateState()
    {

        try
        {
            if (boss.EnemyHP == 30) SetSecondStage();
            else if (boss.EnemyHP <= 0) DestroyBossObjects();
            Invoke("UpdateState", 2f);
        }
        catch (NullReferenceException)
        {
            Destroy(gameObject);
        }
    }

    private void SetSecondStage()
    {
        boss.isVincible = true;
        secondStage.SetActive(true);
    }

    private void DestroyBossObjects()
    {
        Destroy(firstStage);
        Destroy(secondStage);
    }
}
