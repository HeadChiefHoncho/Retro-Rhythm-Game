using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class handles the audio delay before music begins playing.
 * 
 * My implementation uses 2 audio sources, a MultipleAudio script which contains
 * all possible song selections and is used to process obstacles while playing silently,
 * ahead of the actual audio, as well as a regular AudioSource, which is populated based
 * on the player's chosen song and plays out loud as music that the player listens to.
 * 
 * The audio delay is necessary to allow time for the audio processor to detect beats while
 * the audio plays silently, ahead of when the player actually hears it and begins playing.
 */

public class DelayAudio : MonoBehaviour {

    public float delay = 8.0f; // based on speed of obstacles & tiles on screen
    public bool delayDone = false;
    private float startTime;
    
	// Init
	void Start () {
        startTime = Time.time;
	}
	
	void Update () {
        // Detects whether audio delay has completed or not
        if (Time.time >= delay + startTime)
        {
            delayDone = true;
        }
	}
}
