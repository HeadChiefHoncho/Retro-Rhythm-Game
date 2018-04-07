using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayAudio : MonoBehaviour {

    AudioSource music;
    public float delay = 8.0f; // based on speed of obstacles & tiles on screen
    public bool delayDone = false;
    private float startTime;
    private MultipleAudio audioSource;
    public MicInput micInput;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<MultipleAudio>();
        startTime = Time.time;
        music = GetComponent<AudioSource>();
        

	}
	
	// Update is called once per frame
	void Update () {
        if (audioSource.trackSelected && !micInput.startedGame)
        {
            //music.PlayDelayed(delay);
        }
        
        if (Time.time >= delay + startTime)
        {
            delayDone = true;
        }
	}
}
