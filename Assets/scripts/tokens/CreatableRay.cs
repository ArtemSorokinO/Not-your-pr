using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatableRay : MonoBehaviour
{
    [SerializeField]
    private int rayDamage = 1;
    private Transform target;
    private Vector2 direction;
    private bool canDamage = false;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Transform>();

        direction = target.position - transform.position;
        var rotation = (Mathf.Atan(direction.y / direction.x) * Mathf.Rad2Deg);
        if (target.position.x < transform.position.x)
        {
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }
        gameObject.transform.rotation = Quaternion.Euler(0, 0, rotation);
    }


    //public void mergeToDott(GameObject createdByDott)
    //{
    //    gameObject.transform.SetParent(createdByDott.transform, true);
    //}

    void setCollider()
    {
        canDamage= true;
    }

    void stopCollider()
    {
        canDamage = false;
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (canDamage && collider.gameObject.tag == "Player")
        {

                //Debug.Log("Collisioned by ray");
                GameObject.FindGameObjectWithTag("Player")?.GetComponent<Player>().changeHP(rayDamage);
                canDamage = false;
        }
    }
}
