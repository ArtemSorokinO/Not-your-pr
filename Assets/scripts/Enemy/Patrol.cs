using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public GameObject[] points = new GameObject[9];
    private int action = 0;
    private int randPoint = 0;
    public float speed = 3f;
    private bool isWaiting = false;

    void Start()
    {
       
    }

    
    void Update()
    {
        if (action == 0 && GetComponent<Enemy>().isAlive)
        {
            if (points[randPoint].transform.parent != null)
            {
                for (int i = 0; i < points.Length; i++)
                {
                    points[i].transform.parent = null;
                }
                
            }
            if (transform.position != points[randPoint].transform.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, points[randPoint].transform.position, speed * Time.deltaTime);
                
            } else
            {
                if (!isWaiting)
                {
                    isWaiting = true;
                    StartCoroutine(Wait(Random.Range(1f, 3f)));
                    randPoint = Random.Range(0, points.Length);
                }
            }
            
        }
    }

    private void OnCollisionEnter2D()
    {
        if (action == 0)
        {
            randPoint = Random.Range(0, points.Length);
        }
    }

    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        isWaiting = false;
    } 
}
