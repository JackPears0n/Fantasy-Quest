using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ProjectileCombat : MonoBehaviour
{
    public GameObject projectile;

    void Update()
    {
        Throw();
    }
    void Throw()
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
            rb.transform.position = new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z);

            Thread.Sleep(1);
        }
    }
}
