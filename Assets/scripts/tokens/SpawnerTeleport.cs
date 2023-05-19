using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTeleport : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemyList = new List<GameObject>();

    [SerializeField] private float deltaX = 0;
    [SerializeField] private float deltaY = 0;

    void SpawnEnemyes()
    {
        Instantiate(
            enemyList[Random.Range(0, enemyList.Count)],
            new Vector2(transform.position.x + deltaX, transform.position.y + deltaY),
            Quaternion.identity);
    }

}
