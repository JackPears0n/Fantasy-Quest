using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperScript : MonoBehaviour
{
    LayerMask floorLayerMask;
    Color hitColour = Color.white;
    float raylength;
    public bool colCheck;

    // Start is called before the first frame update
    void Start()
    {
        floorLayerMask = LayerMask.GetMask("Floor");
    }

    public bool DoRayCollisionCheck()
    {
        float rayLength = 0.5f;

        //cast a ray downward of length 1
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, rayLength, floorLayerMask);

        hit = Physics2D.Raycast(transform.position, -Vector2.up, rayLength, floorLayerMask);

        Debug.DrawRay(transform.position, -Vector2.up * rayLength, (hit.collider != null) ? Color.green : Color.white);

        return hit.collider != null;
    }
    public void FlipObject(bool flip)
    {
        // get the SpriteRenderer component
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        if (flip == true)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
}
