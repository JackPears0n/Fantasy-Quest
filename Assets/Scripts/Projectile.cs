using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    public void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "Enemy" || gameObject.tag == "Ground")
        {
            gameObject.SetActive(false);
        }
    }
}
