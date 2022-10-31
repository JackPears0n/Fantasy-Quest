using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public bool touchingPlatform;
    private Animator anim;
    bool isJumping;
    HelperScript helper;
    public GameObject projectile;
    bool isGrounded;
    private int curentHealth;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 5.5F;
        touchingPlatform = false;
        anim = GetComponent<Animator>();
        helper = gameObject.AddComponent<HelperScript>();
    }

    // Update is called once per frame
    void Update()
    {

        helper.DoRayCollisionCheck();

        isGrounded = helper.DoRayCollisionCheck();
        Vector2 vel = rb.velocity;
        anim.SetBool("run", false);
        anim.SetBool("jumping", false);

        // check for walk left button
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            vel.x = -3;
            helper.FlipObject(true);    // this will execute the method in HelperScript.cs
            anim.SetBool("run", true);
        }

        // check for walk right button
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            vel.x = 3;
            helper.FlipObject(false);    // this will execute the method in HelperScript.c
            anim.SetBool("run", true);
        }

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && (isGrounded == true))
        {
            isJumping = true;
            vel.y = 6;
            if (isJumping == true)
            {
                anim.SetBool("jumping", true);
            }
            else
            {
                anim.SetBool("jumping", false);
            }
        }

        rb.velocity = vel;

    }
}
