using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayAudio : MonoBehaviour {

    AudioSource music;
    public float delay = 8.0f; // based on speed of obstacles & tiles on screen
    public bool delayDone = false;
    private float startTime;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        music = GetComponent<AudioSource>();
        music.PlayDelayed(delay);

	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= delay + startTime)
        {
            delayDone = true;
        }
	}
}
