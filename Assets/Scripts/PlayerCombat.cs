using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    Rigidbody2D rb;

    [Header("Animator")]
    public Animator animator;
    int attackNum;

    [Header("Target layers")]
    public LayerMask enemyLayers;

    [Header("Melee")]
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage;

    [Header("Ranged")]
    public GameObject projectile;
    public int projectileDamage;
    public Transform shotPoint;
    public float timeBtwnShots;
    public float startTimeBtwnShots;

    // Start is called before the first frame update
    void Start()
    {
        attackNum = 0;
        attackDamage = 20;
        projectileDamage = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();

        //Throw
        if (timeBtwnShots <= 0)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeBtwnShots = startTimeBtwnShots;
            }
        }
        else
        {
            timeBtwnShots -= Time.deltaTime;
        }
        
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Plays the attack animation
            //print(attackNum);

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
            if (attackNum > 2)
            {
                attackNum = 0;
            }

            // Detects the enemies
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            // Damages the enemies
            foreach(Collider2D enemy in hitEnemies)
            {
                //print("We hit" + enemy.name);
                enemy.GetComponent<Health>().TakeDamage(attackDamage);
            }

            animator.SetTrigger("idle");

            Thread.Sleep(1);
        }
        

    }

    void OnCollisionEnter2D()
    {
        Health enemyHealth = projectile.transform.GetComponent<Health>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(projectileDamage);
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
