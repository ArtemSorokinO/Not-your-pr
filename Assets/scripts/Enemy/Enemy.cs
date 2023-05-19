using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    public bool isVincible = true;
    public int maxEnemyHP = 3;
    public int EnemyHP;
    public bool isAlive = true;
    public int enemySpeed = 6;

    [SerializeField]
    private int enemyCost = 1;
    [SerializeField]
    private int enemyDropChance = 6;


    [SerializeField]
    private GameObject lootPrefab;

    private bool directedRight = true;
    private Vector2 moveInput;
    public static Action<int> scoreChange;
    private Transform target;
    private Rigidbody2D rb;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Player.apperOfPlayer += SetTarget;
        EnemyHP = maxEnemyHP;
        SetTarget();
    }

    void SetTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Transform>();
    }

    void Update()
    {
        rb.WakeUp();
        if (directedRight && target.position.x < transform.position.x)
        {
            Flip();
        }
        else if (!directedRight && target.position.x > transform.position.x)
        {
            Flip();
        }
    }

    public void TakeDamage(int damage, List<string> tags)
    {
        if (isVincible)
        {
            EnemyHP -= damage;
            if (tags.Contains("fire"))
            {
                //Fire();
            }

            anim.SetTrigger("pain");

            if (EnemyHP <= 0)
            {
                Die();
            }
        }

    }

    public void PureDamage(int damage, List<string> tags)
    {
        EnemyHP -= damage;

        anim.SetTrigger("pain");

        if (EnemyHP <= 0)
        {
            Die();
        }
    }

    

    void Die()
    {
        isAlive = false;
        anim.SetBool("isAlive", false);
        GetComponent<Collider2D>().enabled = false;
        var timed = GetComponent<CircleCollider2D>();
        if (timed != null) timed.enabled = false;
        if(UnityEngine.Random.Range(0,101) <= enemyDropChance) 
        { 
            Instantiate(lootPrefab, gameObject.transform.position, Quaternion.identity); 
        }
        scoreChange?.Invoke(enemyCost);
        this.enabled = false;
    }

    private void Flip()
    {
        directedRight = !directedRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    //пока не работает
    private void Fire()
    {
        for (int i = 0; i < 3; i++)
        {

            TakeDamage(i, new List<string>());
        }
    }
}
