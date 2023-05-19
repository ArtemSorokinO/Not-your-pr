using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingObelisk : MonoBehaviour
{
    [SerializeField] private List<GameObject> projectileTipes;
    [SerializeField] private Animator anim;
    [SerializeField] private float attackRateMax;
    [SerializeField] private float attackRateMin;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackDispersMax;
    [SerializeField] private int countOfAttacksMax;
    [SerializeField] private int countOfAttacksMin;
    private float nextTimeAttack = 2f;
    private Transform player;

    void Awake()
    {
        nextTimeAttack = Random.Range(attackRateMin, attackRateMax);
        Player.apperOfPlayer += SetTarget;
        SetTarget();
    }

    void OnDisable()
    {
        Player.apperOfPlayer -= SetTarget;
    }

    void SetTarget()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Transform>();
    }

    void Update()
    {
        if (anim.GetBool("isAlive") && nextTimeAttack <= Time.time && Vector3.Distance(player.position, transform.position) < attackRange )
        {
            nextTimeAttack = Time.time + 1f / (Random.Range(attackRateMin, attackRateMax) / 10);
            Attack();
        } else if (!anim.GetBool("isAlive")) Destroy(this);
    }

    void Attack()
    {
        var x = player.position.x;
        var y = player.position.y;
        var countOfAttacks = Random.Range(countOfAttacksMin, countOfAttacksMax);
        for (int i = 0; i < countOfAttacksMax; i++)
        {
            var projectile = Instantiate(projectileTipes[Random.Range(0, projectileTipes.Count)],
                new Vector2(x + Random.Range(-attackDispersMax, attackDispersMax),
                    y + Random.Range(-attackDispersMax, attackDispersMax)),
                Quaternion.identity);
        }
    }
}
