using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjectOnDeath : MonoBehaviour
{
    [SerializeField]
    private float offsetX = 0;
    [SerializeField]
    private float offsetY = 0;
    [SerializeField]
    private GameObject gmobject;

    
    void CreateObject()
    {
        Instantiate(
            gmobject,
            new Vector2(transform.position.x + offsetX, transform.position.y + offsetY),
            Quaternion.identity);
    }
}
