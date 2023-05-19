using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grassSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    [SerializeField]
    private int minCount = 10;
    [SerializeField]
    private int maxCount = 26;

    void Start()
    {
        var parent = gameObject.transform;
        for (int i = 0; i < Random.Range(minCount, maxCount); i++)
        {
            var grass = Instantiate(obj, new Vector2(transform.position.x + Random.Range(-8, 8), transform.position.y + Random.Range(-7, 8)), Quaternion.identity);
            grass.transform.SetParent(parent);
        }
    }
}
