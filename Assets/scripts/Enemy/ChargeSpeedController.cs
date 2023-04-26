using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeSpeedController : MonoBehaviour
{
    private bool attackPhase = true;
    private float nextTimeAttack = 0f;
    [SerializeField] private float attackRateMin = 4f;
    [SerializeField] private float attackRateMax = 8f;

    void Update()
    {
        if (nextTimeAttack <= Time.time)
        {
            if (attackPhase)
            {
                nextTimeAttack = Time.time + 5.3f;
                gameObject.GetComponent<PlayerChargeTracking>().enabled = true;
                attackPhase= false;

            }
            else
            {
                nextTimeAttack = Time.time + (Random.Range(attackRateMin, attackRateMax));
                gameObject.GetComponent<PlayerChargeTracking>().enabled = false;
                attackPhase= true;
            }
        }
    }
}
