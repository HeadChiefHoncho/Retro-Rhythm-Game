using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAfterSongSelected : MonoBehaviour {

    private MultipleAudio audioSource;
    private GameObject playerContainer;
    private SpriteRenderer spriteRender;

    // Use this for initialization
    void Start () {

        playerContainer = GameObject.Find("Player Container");

        audioSource = playerContainer.transform.GetChild(0).gameObject.GetComponent<MultipleAudio>();
        spriteRender = GetComponent<SpriteRenderer>();
        spriteRender.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (audioSource.trackSelected)
        {
            spriteRender.enabled = true;
        }
	}
}
