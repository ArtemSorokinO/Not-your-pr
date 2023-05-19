using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radiusDamageToEnemy : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private int attackDamage = 1;
    [SerializeField] List<string> tags;


    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage, tags);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null ) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
