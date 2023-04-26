using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTeleport : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemyList = new List<GameObject>();

    void SpawnEnemyes()
    {
        Instantiate(
            enemyList[Random.Range(0, enemyList.Count)],
            new Vector2(transform.position.x, transform.position.y),
            Quaternion.identity);
    }

}
