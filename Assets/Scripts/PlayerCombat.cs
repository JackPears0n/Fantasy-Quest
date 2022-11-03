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
        Throw();
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

    void Throw()
    {
        float moveDirection = 1.5f;

        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.F))
        {
            // Instantiate the bullet at the position and rotation of the player
            GameObject clone;
            clone = Instantiate(projectile);

            // get the rigidbody component
            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();

            // set the velocity
            rb.velocity = new Vector3(15 * moveDirection, 0, 0);

            // set the position close to the player
            rb.transform.position = new Vector3(transform.position.x + 1, transform.position.y + 1.5f, transform.position.z);

            // Detects the enemies
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            // Damages the enemies
            foreach (Collider2D enemy in hitEnemies)
            {
                //print("We hit" + enemy.name);
                enemy.GetComponent<Health>().TakeDamage(attackDamage);
            }

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
