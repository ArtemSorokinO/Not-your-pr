using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretRoomSpawner : MonoBehaviour
{
    [SerializeField] private GameObject miniBossPrefab;
    [SerializeField] private GameObject spawnPoint;
    public void Open()
    {
        gameObject.GetComponent<Animator>().enabled = true; 
        Instantiate(miniBossPrefab, spawnPoint.transform.position, Quaternion.identity);
        this.enabled = false;
    }
}
