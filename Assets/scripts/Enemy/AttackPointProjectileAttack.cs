using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPointProjectileAttack : MonoBehaviour
{
    [SerializeField] private List<GameObject> projectileTipes;
    [SerializeField] private Animator anim;
    [SerializeField] private List<Transform> attackPoints;
    [SerializeField] private float attackRateMax;
    [SerializeField] private float attackRateMin;
    [SerializeField] private float attackRange;
    private float nextTimeAttack = 0f;
    private Transform player;

    void Awake()
    {
        Player.apperOfPlayer += SetTarget;
        SetTarget();
    }

    void SetTarget()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Transform>();
    }

    void Update()
    {
        if (nextTimeAttack <= Time.time && Vector3.Distance(player.position, transform.position) < attackRange && anim.GetBool("isAlive"))
        {
            nextTimeAttack = Time.time + 1f / ((Random.Range(attackRateMin, attackRateMax) / 10));
            anim.SetTrigger("attack");
        }
    }

    void Attack()
    {
        foreach (var AttackPoint in attackPoints)
        {
            var projectile = Instantiate(projectileTipes[Random.Range(0, projectileTipes.Count)], new Vector2(AttackPoint.position.x, AttackPoint.position.y), Quaternion.identity);
            if (projectile.GetComponent<CreatableWaterDragonWithMerge>() != null) projectile.GetComponent<CreatableWaterDragonWithMerge>()?.mergeToDott(gameObject);
        }
    }
}
