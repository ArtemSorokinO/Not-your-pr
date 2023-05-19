using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBreathFlip : MonoBehaviour
{
    private bool directedRight = true;
    private Transform target;
    void Start()
    {
        target = transform.parent.transform;
        if (directedRight && target.position.x < transform.position.x)
        {
            Flip();
        }
        else if (!directedRight && target.position.x > transform.position.x)
        {
            Flip();
        }
    }

    private void Flip()
    {
        directedRight = !directedRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
