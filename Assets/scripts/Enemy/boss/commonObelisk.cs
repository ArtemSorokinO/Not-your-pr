using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class commonObelisk : MonoBehaviour
{
    [SerializeField] private List<GameObject> projectileTipes;
    [SerializeField] private Animator anim;
    [SerializeField] private float attackDispersMax;
    [SerializeField] private int countOfAttacksMax;
    [SerializeField] private int countOfAttacksMin;



    void StartAttack()
    {
        if (anim.GetBool("isAlive"))
        {
            anim.SetTrigger("attack");
        }
        else if (!anim.GetBool("isAlive")) Destroy(this);
    }

    void Attack()
    {
        var x = transform.position.x;
        var y = transform.position.y;
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
