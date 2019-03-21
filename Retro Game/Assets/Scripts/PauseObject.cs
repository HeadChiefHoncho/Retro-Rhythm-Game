using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class implements the pause functionality for moving obstacles.
 * When the game is paused, this class will detect that and ensure that
 * the scrolling game obstacles do not continue to move in the background.
 */

public class PauseObject : MonoBehaviour {

    Vector2 obstacleSpeed = new Vector2(-4, 0);
    PauseButtonHandler pauseButton;

    // Init
    void Start () {
        pauseButton = GameObject.Find("Canvas").GetComponent<PauseButtonHandler>();
    }
	
	void Update () {
		if (!pauseButton.pause && name != "above" && name != "below")
        {
            GetComponent<Rigidbody2D>().velocity = obstacleSpeed;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0);
        }
	}
}
