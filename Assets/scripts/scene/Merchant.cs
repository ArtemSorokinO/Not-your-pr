using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Merchant : MonoBehaviour
{
    public static Action<string> merchantSignal;
    public static Action<bool> merchantClose;

    [SerializeField] private GameObject[] allStolpsGlow;
    
    private int nowSelling = 0;
    private Action[] allSelling = {SellEstus, SellKey, SellExplosion};
    public int[] howManyHowMuch = {20, 50, 20};

    void Awake()
    {
        BuyButton.SellCurrent += SellCurrent;
        BuyButton.RefreshCurrent += ChangeCurrent;
    }

    void OnDisable()
    {
        BuyButton.SellCurrent -= SellCurrent;
        BuyButton.RefreshCurrent -= ChangeCurrent;
    }
    private void ChangeCurrent()
    {
        allStolpsGlow[nowSelling].SetActive(false);
        nowSelling++;
        if (nowSelling >= 3) nowSelling = 0;
        allStolpsGlow[nowSelling].SetActive(true);
    }


    private void SellCurrent()
    {
        var mngr = GameObject.FindGameObjectWithTag("UIManager");
        if (mngr.GetComponent<PraysCount>().currentScore >= howManyHowMuch[nowSelling] && !mngr.GetComponent<InventoryManager>().IsFull())
        {
            
            Enemy.scoreChange.Invoke(-howManyHowMuch[nowSelling]);
            allSelling[nowSelling].Invoke();
            gameObject.GetComponent<Animator>().SetTrigger("sale");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") merchantClose.Invoke(true);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player") merchantClose.Invoke(false);
    }

    private static void SellEstus()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player.GetComponent<StatsHolderPlayer>()) merchantSignal?.Invoke("Estus");
    }

    private static void SellKey()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player.GetComponent<StatsHolderPlayer>()) merchantSignal?.Invoke("SecretKey");
    }

    private static void SellExplosion()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player.GetComponent<StatsHolderPlayer>()) merchantSignal?.Invoke("Explosion");
    }
}
