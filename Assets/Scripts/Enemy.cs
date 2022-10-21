using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Play hurt animation

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        print("Enemy died");
        // Death animation

        // Disable the enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

    }


}