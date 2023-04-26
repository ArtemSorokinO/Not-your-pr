using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatableWaterDragonWithMerge : MonoBehaviour
{
    [SerializeField]
    private int rayDamage = 1;
    private bool canDamage = false;


    public void mergeToDott(GameObject createdByDott)
    {
        gameObject.transform.SetParent(createdByDott.transform);
    }

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

            //Debug.Log("Collisioned by water Dragon");
            GameObject.FindGameObjectWithTag("Player")?.GetComponent<Player>().changeHP(rayDamage);
            canDamage = false;
        }
    }
}
