using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongSelectButtonHandler : MonoBehaviour {

    public Button song1;
    public Button song2;
    public Button song3;
    //public Button song4;
    public GameObject songSelectPanel;
    public GameObject canvas;
    private GameObject playerContainer;
    private GameObject player;
    private GameObject GUI;
    private GameObject line;
    private GameObject mainCamera;
    public MultipleAudio[] audioSource;
    public MicInput micInput;

    // Use this for initialization
    void Start () {

        playerContainer = GameObject.Find("Player Container");
        player = playerContainer.transform.GetChild(0).gameObject;
        player.SetActive(false);

        GUI = GameObject.Find("GUI");
        line = GUI.transform.GetChild(3).gameObject;
        line.SetActive(false);

        mainCamera = GameObject.Find("Main Camera");

        // Select correct song in both audio locations
        //audioSource[0] = playerContainer.transform.GetChild(0).gameObject.GetComponent<MultipleAudio>();
        audioSource[1] = mainCamera.GetComponent<MultipleAudio>();

        canvas = GameObject.Find("Canvas");
        songSelectPanel = canvas.transform.GetChild(5).gameObject;
        songSelectPanel.SetActive(false);

        Button s1 = song1.GetComponent<Button>();
        Button s2 = song2.GetComponent<Button>();
        Button s3 = song3.GetComponent<Button>();
        //Button s4 = song4.GetComponent<Button>();

        s1.onClick.AddListener(PickSong1);
        s2.onClick.AddListener(PickSong2);
        s3.onClick.AddListener(PickSong3);
        //s4.onClick.AddListener(PickSong4);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void PickSong1()
    {
        player = playerContainer.transform.GetChild(0).gameObject;
        player.SetActive(true);

        line = GUI.transform.GetChild(3).gameObject;
        line.SetActive(true);

        //micInput.startedGame = true;

        audioSource[0] = playerContainer.transform.GetChild(0).gameObject.GetComponent<MultipleAudio>();
        audioSource[1] = mainCamera.GetComponent<MultipleAudio>();

        audioSource[0].trackSelector = 0;
        audioSource[1].trackSelector = 0;
        audioSource[0].trackSelected = true;
        audioSource[1].trackSelected = true;
        songSelectPanel.SetActive(false);

    }

    void PickSong2()
    {
        player = playerContainer.transform.GetChild(0).gameObject;
        player.SetActive(true);

        line = GUI.transform.GetChild(3).gameObject;
        line.SetActive(true);

        //micInput.startedGame = true;

        audioSource[0] = playerContainer.transform.GetChild(0).gameObject.GetComponent<MultipleAudio>();
        audioSource[1] = mainCamera.GetComponent<MultipleAudio>();

        audioSource[0].trackSelector = 1;
        audioSource[1].trackSelector = 1;
        audioSource[0].trackSelected = true;
        audioSource[1].trackSelected = true;
        songSelectPanel.SetActive(false);
    }

    void PickSong3()
    {
        player = playerContainer.transform.GetChild(0).gameObject;
        player.SetActive(true);

        line = GUI.transform.GetChild(3).gameObject;
        line.SetActive(true);

        //micInput.startedGame = true;

        audioSource[0] = playerContainer.transform.GetChild(0).gameObject.GetComponent<MultipleAudio>();
        audioSource[1] = mainCamera.GetComponent<MultipleAudio>();

        audioSource[0].trackSelector = 2;
        audioSource[1].trackSelector = 2;
        audioSource[0].trackSelected = true;
        audioSource[1].trackSelected = true;
        songSelectPanel.SetActive(false);
    }

    void PickSong4()
    {
        player = playerContainer.transform.GetChild(0).gameObject;
        player.SetActive(true);

        line = GUI.transform.GetChild(3).gameObject;
        line.SetActive(true);

        //micInput.startedGame = true;

        audioSource[0] = playerContainer.transform.GetChild(0).gameObject.GetComponent<MultipleAudio>();
        audioSource[1] = mainCamera.GetComponent<MultipleAudio>();

        audioSource[0].trackSelector = 3;
        audioSource[1].trackSelector = 3;
        audioSource[0].trackSelected = true;
        audioSource[1].trackSelected = true;
        songSelectPanel.SetActive(false);
    }
}
