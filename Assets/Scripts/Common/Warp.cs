using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    private float colliderRadius;
    private void Start()
    {
        colliderRadius = GetComponent<CircleCollider2D>().radius;
    }
    /// <summary>
    /// Called when the game object becomes invisible to the camera
    /// </summary>
   
    private void OnBecameInvisible()
    {
        Vector2 position = transform.position;

        // check left, right, top, and bottom sides
        if (position.x  < ScreenUtils.ScreenLeft ||
            position.x  > ScreenUtils.ScreenRight)
        {
            position.x *= -1;
        }
        if (position.y > ScreenUtils.ScreenTop ||
            position.y < ScreenUtils.ScreenBottom)
        {
            position.y *= -1;
        }

        // move ship
        transform.position = position;
    }

}
