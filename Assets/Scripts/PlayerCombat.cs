using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    int attackNum;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage;
    // Start is called before the first frame update
    void Start()
    {
        attackNum = 0;
        attackDamage = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
            animator.SetTrigger("idle");
        
        }
    }

    void Attack()
    {
        // Plays the attack animation
        print(attackNum);

        if (attackNum == 0)
        {
            animator.SetTrigger("Attack1");
            
        }
        else if (attackNum == 1)
        {
            animator.SetTrigger("Attack2");
            
        }
        else
        {
            animator.SetTrigger("Attack3");
            
        }

        attackNum++;
        if( attackNum>2)
        {
            attackNum = 0;
        }

        // Detects the enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damages the enemies
        foreach(Collider2D enemy in hitEnemies)
        {
            print("We hit" + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }

    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
