using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat : MonoBehaviour
{
    [Header("Fast")]
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Transform attackPoint;
    public LayerMask enemyLayers;
    [SerializeField]
    private float attackRange = 0.5f;
    [SerializeField]
    private float attackrate = 2f;
    public int attackDamage = 1;
    public List<string> tags;


    float nextAttackTime = 0f;
    
    
    void Awake()
    {
        AttackMetod.fAtc += FastAttack;
        AttackMetod.hAtc += HeavyAttack;
    }
    
    void OnDestroy()
    {
        AttackMetod.fAtc -= FastAttack;
        AttackMetod.hAtc -= HeavyAttack;
    }

    //по нажатии кнопки запускается анимация быстрой тычки
    public void FastAttack()
    {
        if (nextAttackTime <= Time.time && GetComponent<Collider2D>().enabled == true)
        {
            nextAttackTime = Time.time + 1f / attackrate;
            animator.SetTrigger("attack first");
        }
    }

    //на каком-то фрейме срабатывает нанесение урона
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
        if (attackPoint == null || heavyAttackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.DrawWireSphere(heavyAttackPoint.position, heavyAttackRange);
    }

    [Header("Heavy")]
    [SerializeField]
    private Transform heavyAttackPoint;
    [SerializeField]
    private float heavyAttackRange = 0.5f;
    [SerializeField]
    private float heavyAttackrate = 1f;
    public int heavyAttackDamage = 2;
    public List<string> heavyTags;

    //по нажатии кнопки запускается анимация тяжёлой тычки
    void HeavyAttack()
    {
        if (nextAttackTime <= Time.time && GetComponent<Collider2D>().enabled == true)
        {
            nextAttackTime = Time.time + 1f / heavyAttackrate;
            animator.SetTrigger("attack second");
        }
    }

    //на каком-то фрейме срабатывает нанесение урона
    void hAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(heavyAttackPoint.position, heavyAttackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(heavyAttackDamage, tags);
        }
    }

}
