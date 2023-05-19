using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracking : MonoBehaviour
{
    [SerializeField]
    private float enemySpeed = 6;
    [SerializeField]
    private float stoppingDistance = 4;
    [SerializeField]
    private float visionDistance = 10;
    [SerializeField]
    private float deltaX = 0;
    [SerializeField]
    private float deltaY = 0;

    private Transform player;
    private Animator anim;
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool running = false;

    void Awake()
    {
        Player.apperOfPlayer += SetTarget;
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
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
        Vector3 direction = player.position - transform.position + new Vector3(deltaX, deltaY);
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movement = direction;
        
    }

    private void FixedUpdate()
    {
        if (GetComponent<Enemy>() != null)
        {
            if (GetComponent<Enemy>().isAlive)
            {
                MoveChar(movement);
                if (!running)
                    anim.SetBool("running", true);
            }
            else 
            { 
                if (running)
                    anim.SetBool("running", false);
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
        if (pos > stoppingDistance && pos < visionDistance)
        {
            rb.MovePosition((Vector2)transform.position + (direction * enemySpeed * Time.deltaTime));
        }
    }

    void OnDisable()
    {
        Player.apperOfPlayer -= SetTarget;
    }
}