using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grassSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;

    void Start()
    {
        for (int i = 0; i < Random.Range(10, 26); i++)
        {
            Instantiate(obj, new Vector2(transform.position.x + Random.Range(-9, 9), transform.position.y + Random.Range(-11, 9)), Quaternion.identity);
        }
    }
}
