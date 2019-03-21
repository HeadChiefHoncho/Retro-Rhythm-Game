using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CalibrationButtonHandler : MonoBehaviour {
 
    // UI Panels
    public GameObject calibPanel;
    public GameObject songSelectPanel;

    // Game canvas
    public GameObject canvas;

    // Text gameobjects
    public GameObject calibInst;
    public GameObject avgInst;
    public GameObject countdown;
    public GameObject continInst;

    // Changing countdownText
    public Text countdownText;

    // Button gameobjects
    public GameObject calib;
    public GameObject avg;
    public GameObject done;
    public GameObject contin;

    public bool calibrating = false;
    public bool calibrationSet = false; // set to true once calibration is complete
    private float timeRemaining = 3;

    void Start () {
        canvas = GameObject.Find("Canvas");

        // set calibration panel active
        calibPanel = canvas.transform.GetChild(6).gameObject;
        calibPanel.SetActive(true);

        // set 1st text to active
        calibInst = calibPanel.transform.GetChild(1).gameObject;
        calibInst.SetActive(true);

        // set 1st button to active
        calib = calibPanel.transform.GetChild(5).gameObject;
        calib.SetActive(true);

        // set panel objects invisible
        songSelectPanel = canvas.transform.GetChild(5).gameObject;
        songSelectPanel.SetActive(false);

        // set remaining text objects invisible
        avgInst = calibPanel.transform.GetChild(2).gameObject;
        avgInst.SetActive(false);
        countdown = calibPanel.transform.GetChild(3).gameObject;
        countdown.SetActive(false);
        continInst = calibPanel.transform.GetChild(4).gameObject;
        continInst.SetActive(false);

        // set remaining button objects invisible
        avg = calibPanel.transform.GetChild(6).gameObject;
        avg.SetActive(false);
        done = calibPanel.transform.GetChild(7).gameObject;
        done.SetActive(false);
        contin = calibPanel.transform.GetChild(8).gameObject;
        contin.SetActive(false);

        // assign button listeners
        Button calibButton = calib.GetComponent<Button>();
        calibButton.onClick.AddListener(OnCalib);
        Button avgButton = avg.GetComponent<Button>();
        avgButton.onClick.AddListener(OnAvg);
        Button doneButton = done.GetComponent<Button>();
        doneButton.onClick.AddListener(OnDone);
        Button continButton = contin.GetComponent<Button>();
        continButton.onClick.AddListener(OnContin);
    }

    // Calibrate Button Handler (begins mic calibration process)
    void OnCalib()
    {
        calibPanel = canvas.transform.GetChild(6).gameObject;
        calibrationSet = false;

        // make calib button/text invisible
        calibInst = calibPanel.transform.GetChild(1).gameObject;
        calibInst.SetActive(false);
        calib = calibPanel.transform.GetChild(5).gameObject;
        calib.SetActive(false);

        // make next set of button/text visible
        avgInst = calibPanel.transform.GetChild(2).gameObject;
        avgInst.SetActive(true);
        avg = calibPanel.transform.GetChild(6).gameObject;
        avg.SetActive(true);
    }

    void OnAvg()
    {
        calibPanel = canvas.transform.GetChild(6).gameObject;

        // make avg button invisible
        avg = calibPanel.transform.GetChild(6).gameObject;
        avg.SetActive(false);

        // make next set of button/text visible
        countdown = calibPanel.transform.GetChild(3).gameObject;
        countdown.SetActive(true);

        // OPERATE COUNTDOWN
        StartCoroutine("Countdown");
        timeRemaining = 3;
    }

    IEnumerator Countdown()
    {
        countdownText = countdown.GetComponent<Text>();
        countdownText.text = timeRemaining + "...";
        calibrating = true;

        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1);
            timeRemaining--;
            countdownText.text = timeRemaining + "...";
        }
        countdown.SetActive(false);
        done = calibPanel.transform.GetChild(7).gameObject;
        done.SetActive(true);
        calibrating = false;
        calibrationSet = true;
    }

    void OnDone()
    {
        if (!calibrationSet)
        {
            return;
        }

        // make avg text invisible
        avgInst = calibPanel.transform.GetChild(2).gameObject;
        avgInst.SetActive(false);

        // make done button invisible
        done = calibPanel.transform.GetChild(7).gameObject;
        done.SetActive(false);

        // make continue to song select text/button visible
        continInst = calibPanel.transform.GetChild(4).gameObject;
        continInst.SetActive(true);
        contin = calibPanel.transform.GetChild(8).gameObject;
        contin.SetActive(true);
    }

    // Continue to Song Select Button Handler (ends mic calibration process)
    void OnContin()
    {
        calibPanel = canvas.transform.GetChild(6).gameObject;
        calibPanel.SetActive(false); // hide calibration instructions
        calibrationSet = true;

        songSelectPanel = canvas.transform.GetChild(5).gameObject;
        songSelectPanel.SetActive(true);
    }
}
