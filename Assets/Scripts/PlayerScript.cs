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
    int health;
    HelperScript helper;
    bool alive;
    public GameObject projectile;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        speed = 5.5F;
        touchingPlatform = false;
        anim = GetComponent<Animator>();
        //isJumping = false;
        health = 100;
        alive = true;
        helper = gameObject.AddComponent<HelperScript>();
    }

    // Update is called once per frame
    void Update()
    {

        helper.DoRayCollisionCheck();
        Shoot();

        isGrounded = helper.DoRayCollisionCheck();
        Vector2 vel = rb.velocity;
        anim.SetBool("run", false);
        anim.SetBool("jumping", false);

        if (health <= 0)
        {
            alive = false;
        }

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
            vel.y = 7;
            if (isJumping == true)
            {
                anim.SetBool("jumping", true);
            }
            else
            {
                anim.SetBool("jumping", false);
            }
        }

        /*
        // check for jump button
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && (isGrounded == true))
        {
            isJumping=true;
            vel.y = 7;
            anim.SetBool("walk", false);
        }

        // check for jumpflag
        if (isJumping == true)
        {
            anim.SetBool("jump", true);
        }
        else
        {
            anim.SetBool("jump", false);
        }
        */
        rb.velocity = vel;

    }


    // destroy object
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            Destroy(collision.gameObject);
        }
    }

    void Shoot()
    {
        int moveDirection = 1;

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
            rb.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);

            Thread.Sleep(1);
        }
    }
}
