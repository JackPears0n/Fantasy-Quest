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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }

}
