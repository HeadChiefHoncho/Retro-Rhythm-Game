using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicInput : MonoBehaviour {

    AudioClip micInput;
    public float aboveTH = 0.14f;
    public float belowTH = 0.04f;
    public bool activated = false;
    GameObject player;
    Animator playerAnim;
    int numSamples;
    float avgLevel;
    float lastActivateTime;
    public float cooldown = 0.095f;
    float calibrateSeconds = 3;
    public float controllerRange = 0.06f;
    PauseButtonHandler pauseButton;

    // Use this for initialization
    void Start () {
        pauseButton = GameObject.Find("Canvas").GetComponent<PauseButtonHandler>();
        player = GameObject.Find("player");
        playerAnim = player.GetComponent<Animator>();
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
        if (!pauseButton.pause)
        {
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

            if (level > (aboveTH + avgLevel) && !activated && (Time.time - lastActivateTime) > cooldown)
            {
                // Loud noise detected
                lastActivateTime = Time.time;
                Debug.Log(level);

                playerAnim.SetTrigger("upbeat");

                activated = true;
            }
            if (level <= (aboveTH + avgLevel - controllerRange) && level > (belowTH + avgLevel)
                && !activated && (Time.time - lastActivateTime) > cooldown)
            {
                // Low noise detected
                lastActivateTime = Time.time;
                //Debug.Log(level);

                playerAnim.SetTrigger("downbeat");

                activated = true;
            }
            if (level <= (belowTH + avgLevel) && activated)
            {
                // No noise detected
                activated = false;
            }
        }
	}
}
