using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseObject : MonoBehaviour {

    public Vector2 obstacleSpeed = new Vector2(-4, 0);
    PauseButtonHandler pauseButton;

    // Use this for initialization
    void Start () {
        pauseButton = GameObject.Find("Canvas").GetComponent<PauseButtonHandler>();
    }
	
	// Update is called once per frame
	void Update () {
		if (!pauseButton.pause && name != "above" && name != "below")
        {
            GetComponent<Rigidbody2D>().velocity = obstacleSpeed;
        } else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0);
        }
	}
}
