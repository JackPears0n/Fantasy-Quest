using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    /*
    public float speed;
    public float distance;
    public float projectileDamage = 10;
    public LayerMask whatIsSolid;

    public void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                print("Enemy must take damage");
                hitInfo.collider.GetComponent<Health>().TakeDamage(projectileDamage);
            }
        }

        transform.Translate(transform.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "Enemy" || gameObject.tag == "Ground")
        {
            gameObject.SetActive(false);
        }
    }
    */
}
