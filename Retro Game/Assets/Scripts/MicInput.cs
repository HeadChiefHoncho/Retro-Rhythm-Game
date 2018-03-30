using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicInput : MonoBehaviour {

    AudioClip micInput;
    public float cheeseTH = 0.14f;
    public float controllerTH = 0.04f;
    public bool activated = false;
    GameObject cheese;
    GameObject controller;
    int numSamples;
    float avgLevel;
    float lastActivateTime;
    public float cooldown = 0.095f;
    float calibrateSeconds = 3;
    public float controllerRange = 0.06f;

    // Use this for initialization
    void Start () {
        cheese = GameObject.Find("cheese sprite");
        controller = GameObject.Find("controller sprite");
        if (Microphone.devices.Length > 0)
        {
            micInput = Microphone.Start(Microphone.devices[0], true, 999, 44100);
        } else
        {
            // do error handling here
            Debug.Log("NO MIC WOOPSIE");
        }
	}
	
	// Update is called once per frame
	void Update () {
        int dec = 128;
        float[] waveData = new float[dec];
        int micPosition = Microphone.GetPosition(Microphone.devices[0]) - (dec + 1); // null = first mic
        if (micPosition < 0) micPosition = 0;
        micInput.GetData(waveData, micPosition);

        // Getting a peak on last 128 samples
        float levelMax = 0;
        for (int i = 0; i < dec; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }


        float level = Mathf.Sqrt(Mathf.Sqrt(levelMax));

        if (Time.time <= calibrateSeconds)
        {
            numSamples++;
            avgLevel -= avgLevel / numSamples;
            avgLevel += level / numSamples;
        }

        if (level > (cheeseTH + avgLevel) && !activated && (Time.time - lastActivateTime) > cooldown)
        {
            lastActivateTime = Time.time;
            Debug.Log(level);
            if (cheese.transform.position.y == 0)
            {
                cheese.transform.Translate(new Vector3(0, 1, 0));
            } else
            {
                cheese.transform.Translate(new Vector3(0, -1, 0));
            }
            activated = true;
        }
        if (level <= (cheeseTH + avgLevel - controllerRange) && level > (controllerTH + avgLevel)
            && !activated && (Time.time - lastActivateTime) > cooldown)
        {
            lastActivateTime = Time.time;
            //Debug.Log("Waaaa no noise");
            Debug.Log(level);
            if (controller.transform.position.y == 0)
            {
                controller.transform.Translate(new Vector3(0, 1, 0));
            }
            else
            {
                controller.transform.Translate(new Vector3(0, -1, 0));
            }
            activated = true;
        }
        if (level <= (controllerTH + avgLevel) && activated)
        {
            activated = false;
        }
	}
}
