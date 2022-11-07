using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Target layers")]
    public LayerMask enemyLayers;

    [Header("Ranged")]
    public Transform projectile;
    public Transform throwPoint;
    public float attackRange = 0.5f;

    [Header("Damage")]
    public int projectileDamage;

    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        Health enemyHealth = projectile.transform.GetComponent<Health>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(projectileDamage);
            // Detects the enemies
            PolygonCollider2D[] hitEnemies = (PolygonCollider2D[])Physics2D.OverlapCircleAll(throwPoint.position, attackRange, enemyLayers);

            // Damages the enemies
            foreach(PolygonCollider2D enemy in hitEnemies)
            {
                //print("We hit" + enemy.name);
                enemy.GetComponent<Health>().TakeDamage(projectileDamage);
            }
        }
    }

}
