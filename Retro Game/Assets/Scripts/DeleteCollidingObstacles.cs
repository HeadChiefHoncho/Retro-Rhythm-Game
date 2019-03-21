using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 
 * This class allows the scrolling obstacles to be deleted when they
 * collide with their counterparts to the left of the edge of the screen.
 * It is an easy way to handle the rotation of assets in the scene.
 */

public class DeleteCollidingObstacles : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(collider.gameObject);
    }
}
