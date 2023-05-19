using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalRay : MonoBehaviour
{

    [SerializeField]
    private int rayDamage = 1;
    private bool canDamage = false;

    void setCollider()
    {
        canDamage = true;
    }

    void stopCollider()
    {
        canDamage = false;
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (canDamage && collider.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player")?.GetComponent<Player>().changeHP(rayDamage);
            canDamage = false;
        }
    }
}
