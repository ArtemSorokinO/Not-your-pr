using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Boss spawned in ");
        if (collider.gameObject.tag == "Player")
        {
            SpawnBoss();
        }
        Destroy(this.gameObject);
    }

    void SpawnBoss()
    {
        Instantiate(
            enemy,
            new Vector2(transform.position.x , transform.position.y),
            Quaternion.identity);
    }
}
