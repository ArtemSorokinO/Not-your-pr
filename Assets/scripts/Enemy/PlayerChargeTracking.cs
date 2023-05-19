using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChargeTracking : MonoBehaviour
{
    public float enemySpeed = 6;
    [SerializeField]
    private float stoppingDistance = 4;
    [SerializeField]
    private float visionDistance = 10;
    [SerializeField]
    private Transform player;
    private Animator anim;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Awake()
    {
        Player.apperOfPlayer += SetTarget;
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("running", true);
        SetTarget();
    }

    void SetTarget()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Transform>();
    }

    void Update()
    {
        if (GetComponent<Enemy>() != null)
        {
            if (GetComponent<Enemy>().isAlive)
            {
                moveTarget();
            }
        }
        else
        {
            moveTarget();
        }

    }

    void moveTarget()
    {
        var pos = Vector2.Distance(player.position, transform.position);
        if (pos > stoppingDistance && pos < visionDistance)
        {
            Vector3 direction = player.position - transform.position;
            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            direction.Normalize();
            movement = direction;
        }
    }

    private void FixedUpdate()
    {
        if (GetComponent<Enemy>() != null)
        {
            if (GetComponent<Enemy>().isAlive)
            {
                MoveChar(movement);
            }
        }
        else
        {
            MoveChar(movement);
        }
    }
    private void MoveChar(Vector2 direction)
    {
        var pos = Vector2.Distance(player.position, transform.position);
        if (pos < visionDistance)
        {
            rb.MovePosition((Vector2)transform.position + (direction * enemySpeed * Time.deltaTime));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            //Debug.Log("Enemy collisioned with zabor or enother mob");
            Vector3 direction = player.position - transform.position;
            direction.Normalize();
            movement = direction;
        }
    }

    void OnDisable()
    {
        Player.apperOfPlayer -= SetTarget;
    }
}