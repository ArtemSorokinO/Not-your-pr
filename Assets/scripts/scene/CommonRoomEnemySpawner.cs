using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonRoomEnemySpawner : MonoBehaviour
{
    [SerializeField]
    private int countOfEnemyes = 5;
    //roomRange is 9
    private float maxSpawnRange = 7;

    [SerializeField]
    private List<GameObject> enemyList = new List<GameObject>();

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Enemyes spawned in ");
        if (collider.gameObject.tag == "Player")
        {
            SpawnEnemyes(countOfEnemyes);
        }
        Destroy(this.gameObject);
    }

    void SpawnEnemyes(int countOfEnemyes)
    {
        for (int i = 0; i < countOfEnemyes; i++)
        {
            Instantiate(
                enemyList[Random.Range(0, enemyList.Count)], 
                new Vector2(
                    transform.position.x + Random.Range(-maxSpawnRange, maxSpawnRange), 
                    transform.position.y + Random.Range(-maxSpawnRange - 2, maxSpawnRange)
                    ),
                Quaternion.identity);
        }
    }

}
