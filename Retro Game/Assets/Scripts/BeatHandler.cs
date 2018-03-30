using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatHandler : MonoBehaviour {

    public bool activated = false;
    GameObject controller;
    GameObject above;
    GameObject below;

    // Use this for initialization
    void Start () {
        //Select the instance of AudioProcessor and pass a reference
        //to this object
        AudioProcessor processor = FindObjectOfType<AudioProcessor>();
        processor.onBeat.AddListener(onOnbeatDetected);
        processor.onSpectrum.AddListener(onSpectrum);
        controller = GameObject.Find("controller sprite");
        above = GameObject.Find("orange");
        below = GameObject.Find("blue");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //this event will be called every time a beat is detected.
    //Change the threshold parameter in the inspector
    //to adjust the sensitivity
    void onOnbeatDetected()
    {

        above.GetComponent<Renderer>().enabled = !above.GetComponent<Renderer>().enabled;
        below.GetComponent<Renderer>().enabled = !below.GetComponent<Renderer>().enabled;
        //Debug.Log("Beat!!!");
        /*if (controller.transform.position.y == 0)
        {
            controller.transform.Translate(new Vector3(0, 1, 0));
        }
        else
        {
            controller.transform.Translate(new Vector3(0, -1, 0));
        }*/
    }

    //This event will be called every frame while music is playing
    void onSpectrum(float[] spectrum)
    {
        //The spectrum is logarithmically averaged
        //to 12 bands

        for (int i = 0; i < spectrum.Length; ++i)
        {
            Vector3 start = new Vector3(i, 0, 0);
            Vector3 end = new Vector3(i, spectrum[i], 0);
            Debug.DrawLine(start, end);
        }
    }
}
