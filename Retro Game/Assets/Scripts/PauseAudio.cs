using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PauseAudio : MonoBehaviour {

    PauseButtonHandler pauseButton;
    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        pauseButton = GameObject.Find("Canvas").GetComponent<PauseButtonHandler>();
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		if (pauseButton.pause)
        {
            audioSource.Pause();
        } else
        {
            audioSource.UnPause();
        }
	}
}
