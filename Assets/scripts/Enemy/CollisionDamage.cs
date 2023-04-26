using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public int damage = 1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collisioned with player");
            GameObject.FindGameObjectWithTag("Player")?.GetComponent<Player>().changeHP(damage);
        }
        
    }
}
