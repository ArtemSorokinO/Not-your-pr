using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rotation : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;

    void FixedUpdate()
    {
        float angle = transform.rotation.eulerAngles.z;
        transform.Rotate(0,0,rotateSpeed * 1f * Time.deltaTime);

    }

}
