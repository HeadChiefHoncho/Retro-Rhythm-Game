using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CalibrationButtonHandler : MonoBehaviour {

    public Button contin;
    //public Button resume;
    //public Button restart;
    //public Button mainMenu;
    public GameObject calibPanel;
    public GameObject songSelectPanel;
    public GameObject canvas;
    public bool calibrationSet = false; // set to true once calibration is complete
    //public bool pause = false;

    /*DelayAudio delayAudio;
    public MultipleAudio multipleAudio;
    public MicInput micInput;
    public MultipleAudio[] audioSource;
    public AudioSource music;*/

    // Use this for initialization
    void Start () {
        canvas = GameObject.Find("Canvas");
        calibPanel = canvas.transform.GetChild(6).gameObject;
        calibPanel.SetActive(true);

        songSelectPanel = canvas.transform.GetChild(5).gameObject;
        songSelectPanel.SetActive(false);

        Button c = contin.GetComponent<Button>();
        c.onClick.AddListener(OnContinue);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // Continue Button Handler
    void OnContinue()
    {
        calibPanel = canvas.transform.GetChild(6).gameObject;
        calibPanel.SetActive(false); // hide calibration instructions
        calibrationSet = true;

        songSelectPanel = canvas.transform.GetChild(5).gameObject;
        songSelectPanel.SetActive(true);
    }
}
