using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class handles the background continuously scrolling
 * behind the gameplay.
 */

public class ScrollBackground : MonoBehaviour {

    Vector3 nextBackgroundOrig;
    Vector2 obstacleSpeed = new Vector2(-.2f, 0);

    GameObject background;
    GameObject nextBackground;
    GameObject newBackground;
    GameObject backgroundCollider;

    void Start()
    {
        // Get origin position of background for copying
        background = GameObject.Find("GUI/background");
        nextBackground = GameObject.Find("GUI/next background");
        backgroundCollider = GameObject.Find("GUI/background collider");
        backgroundCollider.transform.position = new Vector3(background.transform.position.x - 40, background.transform.position.y);
        nextBackgroundOrig = nextBackground.transform.position;
        background.GetComponent<Rigidbody2D>().velocity = obstacleSpeed;
        nextBackground.GetComponent<Rigidbody2D>().velocity = obstacleSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        newBackground = (GameObject)Instantiate(collider.gameObject);
        newBackground.transform.position = nextBackgroundOrig;
        newBackground.GetComponent<Rigidbody2D>().velocity = obstacleSpeed;
        Destroy(collider.gameObject);
    }
}
