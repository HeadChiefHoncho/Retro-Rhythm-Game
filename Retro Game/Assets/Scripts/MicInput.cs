﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class detects microphone volume levels and moves
 * the player circle accordingly. It also calculates the
 * microphone average levels (calibration).
 */

public class MicInput : MonoBehaviour {

    // Initial Volume Thresholds and Constants
    public float aboveTH = 0.35f;
    public float belowTH = 0.1f;
    public float cooldown = 0.1f;
    public float controllerRange = 0.06f;
    public bool activated = false;
    public bool startedGame = false;
    
    // Game Objects
    GameObject player;
    Animator playerAnim;
    AudioClip micInput;

    // Script References
    public MultipleAudio[] multipleAudio;
    public DelayAudio delayAudio;
    PauseButtonHandler pauseButton;
    CalibrationButtonHandler calibrationHandler;
    ScoreGame scoreGame;

    // Misc
    int numSamples;
    float avgLevel;
    float lastActivateTime;


    void Start () {
        // GameObject and Script Instance Init
        pauseButton = GameObject.Find("Canvas").GetComponent<PauseButtonHandler>();
        calibrationHandler = GameObject.Find("Canvas").GetComponent<CalibrationButtonHandler>();
        multipleAudio[1] = GameObject.Find("Main Camera").GetComponent<MultipleAudio>();
        scoreGame = GameObject.Find("Player Container").transform.GetChild(0).GetComponent<ScoreGame>();

        // Check for user microphone
        if (Microphone.devices.Length > 0)
        {
            micInput = Microphone.Start(Microphone.devices[0], true, 999, 44100);
        }
        else
        {
            Debug.Log("Please connect a microphone to play!");
            Application.Quit();
        }
    }
	
	void Update () {
        // Game setup (runs once per song)
        if (!startedGame && multipleAudio[1].trackSelected && calibrationHandler.calibrationSet)
        {
            player = GameObject.Find("Player Container/player");
            playerAnim = player.GetComponent<Animator>();

            multipleAudio[0] = player.GetComponent<MultipleAudio>();

            startedGame = true;
            player.GetComponent<AudioSource>().clip = multipleAudio[0].tracks[multipleAudio[0].trackSelector];
            player.GetComponent<AudioSource>().PlayDelayed(delayAudio.delay);

            multipleAudio[1].gameObject.GetComponent<AudioSource>().clip = multipleAudio[1].tracks[multipleAudio[1].trackSelector];
            multipleAudio[1].gameObject.GetComponent<AudioSource>().Play();
        }

        // Calibrate Microphone Levels
        if (!startedGame && !calibrationHandler.calibrationSet && calibrationHandler.calibrating)
        {
            CalibrateAvgLevels();
        }

        // Detect Microphone Volume and Move Player Accordingly
        if (!pauseButton.pause && startedGame && !scoreGame.gameOver)
        {
            float level = GetMicLevel();

            // VOLUME ANALYSIS
            if (level > (aboveTH + avgLevel) && !activated && (Time.time - lastActivateTime) > cooldown)
            {
                // Loud noise detected
                lastActivateTime = Time.time;

                playerAnim.SetTrigger("upbeat");

                activated = true;
            }
            if (level <= (aboveTH + avgLevel - controllerRange) && level > (belowTH + avgLevel)
                && !activated && (Time.time - lastActivateTime) > cooldown)
            {
                // Low noise detected
                lastActivateTime = Time.time;

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

    void CalibrateAvgLevels()
    {
        float level = GetMicLevel();

        // CALIBRATE AVG SILENT VOLUME
        numSamples++;
        avgLevel -= avgLevel / numSamples;
        avgLevel += level / numSamples;
    }

    float GetMicLevel()
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

        // MIC VOLUME LEVEL
        return Mathf.Sqrt(Mathf.Sqrt(levelMax));
    }
}
