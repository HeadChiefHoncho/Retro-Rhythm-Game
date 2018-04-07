using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleAudio : MonoBehaviour {

    public AudioClip[] tracks;
    public int trackSelector = 0;
    public bool trackSelected = false;
    //private AudioSource audioSource;
    public MicInput micInput;

	// Use this for initialization
	void Start () {
        //audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (trackSelected && !micInput.startedGame)
        {
            Debug.Log("Track selected!");
            Debug.Log(trackSelector);
            //GetComponent<AudioSource>().clip = tracks[trackSelector];
            //GetComponent<AudioSource>().Play();
        }
	}
}
