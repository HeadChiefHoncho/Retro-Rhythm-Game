using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class holds data about which track has been selected to play.
 * The actual selection logic is done in the SongSelectButtonHandler class.
 */

public class MultipleAudio : MonoBehaviour {

    public AudioClip[] tracks;
    public int trackSelector = 0;
    public bool trackSelected = false;
    public MicInput micInput;

}
