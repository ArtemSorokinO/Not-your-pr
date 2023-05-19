using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyToBoss : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && !GameObject.FindGameObjectWithTag("UIManager").GetComponent<InventoryManager>().IsFull())
        {
            GameObject.FindWithTag("UIManager").GetComponent<InventoryManager>().PutToInventory("BossSpawner");
            Destroy(gameObject);
        }

    }
}
