using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class hides and shows the GUI (which includes the
 * dotted line and player) when the audio is or is not playing.
 */

public class ShowAfterSongSelected : MonoBehaviour {

    private MultipleAudio audioSource;
    private GameObject playerContainer;
    private SpriteRenderer spriteRender;
    ScoreGame scoreGame;

    // Init
    void Start () {

        playerContainer = GameObject.Find("Player Container");
        scoreGame = GameObject.Find("Player Container").transform.GetChild(0).GetComponent<ScoreGame>();

        audioSource = playerContainer.transform.GetChild(0).gameObject.GetComponent<MultipleAudio>();
        spriteRender = GetComponent<SpriteRenderer>();
        spriteRender.enabled = false;
	}
	
	void Update () {
		if (audioSource.trackSelected && !scoreGame.gameOver)
        {
            spriteRender = GetComponent<SpriteRenderer>();
            spriteRender.enabled = true;
        }
    
        if (!audioSource.trackSelected)
        {
            spriteRender.enabled = false;
        }
	}
}
