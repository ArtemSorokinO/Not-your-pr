using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AttackMetod : MonoBehaviour
{
    public static Action fAtc;
    public void FastAttack()
    {
        
        fAtc?.Invoke();
    }

    public static Action hAtc;
    public void HeavyAttack()
    {
        hAtc?.Invoke();
    }
}
