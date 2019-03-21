using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseObject : MonoBehaviour {

    public Vector2 obstacleSpeed;
    PauseButtonHandler pauseButton;
    ScoreGame scoreGame;

    // Use this for initialization
    void Start () {
        pauseButton = GameObject.Find("Canvas").GetComponent<PauseButtonHandler>();
        scoreGame = GameObject.Find("Player Container").transform.GetChild(0).GetComponent<ScoreGame>();
    }
	
	// Update is called once per frame
	void Update () {
		if (!pauseButton.pause && name != "above" && name != "below")
        {
            GetComponent<Rigidbody2D>().velocity = obstacleSpeed;
        } else if (scoreGame.gameOver && name != "above" && name != "below")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0);
        } else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0);
        }
	}
}
