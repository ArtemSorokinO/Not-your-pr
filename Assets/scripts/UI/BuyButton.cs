using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    [SerializeField] private GameObject buyButtons;
    public static Action SellCurrent;
    public static Action RefreshCurrent;
    void Awake()
    {
        Merchant.merchantClose += ButtonSetup;
    }

    void OnDisable()
    {
        Merchant.merchantClose -= ButtonSetup;
    }

    void ButtonSetup(bool i)
    {
        buyButtons.SetActive(i);
    }

    public void Sell()
    {
        SellCurrent.Invoke();
    }

    public void Refresh()
    {
        RefreshCurrent.Invoke();
    }
}
