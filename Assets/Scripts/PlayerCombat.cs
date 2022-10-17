using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    int attackNum;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    // Start is called before the first frame update
    void Start()
    {
        attackNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Attack();
        }
    }

    void Attack()
    {
        if (attackNum == 1)
        {
            animator.SetTrigger("Attack1");
            attackNum++;
        }
        else if (attackNum == 2)
        {
            animator.SetTrigger("Attack2");
            attackNum++;
        }
        else
        {
            animator.SetTrigger("Attack3");
            attackNum = 1;
        }

        Collider2D

    }
}
