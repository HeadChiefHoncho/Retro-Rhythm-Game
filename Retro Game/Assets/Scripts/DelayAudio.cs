using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayAudio : MonoBehaviour {

    AudioSource music;
    public float delay = 8.0f; // based on speed of obstacles & tiles on screen

	// Use this for initialization
	void Start () {
        music = GetComponent<AudioSource>();
        music.PlayDelayed(delay);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
