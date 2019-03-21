using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * This class implements the song selection panel and changes
 * tracks in the MultipleAudio script accordingly.
 */

public class SongSelectButtonHandler : MonoBehaviour {

    // Song Buttons
    public Button song1;
    public Button song2;
    public Button song3;

    // Canvas/Panels
    public GameObject songSelectPanel;
    public GameObject canvas;

    // Player & GUI
    private GameObject playerContainer;
    private GameObject player;
    private GameObject GUI;
    private GameObject line;

    // Audio Srcs
    private GameObject mainCamera;
    public MultipleAudio[] audioSource;
    public MicInput micInput;

    void Start () {

        // Set up player/make invisible
        playerContainer = GameObject.Find("Player Container");
        player = playerContainer.transform.GetChild(0).gameObject;
        player.SetActive(false);

        // Make player line invisible
        GUI = GameObject.Find("GUI");
        line = GUI.transform.GetChild(3).gameObject;
        line.SetActive(false);

        // Set up main camera and the main audio src
        mainCamera = GameObject.Find("Main Camera");
        audioSource[1] = mainCamera.GetComponent<MultipleAudio>();

        // Set up canvas & song selection panel
        canvas = GameObject.Find("Canvas");
        songSelectPanel = canvas.transform.GetChild(5).gameObject;
        songSelectPanel.SetActive(false);

        // Set up song buttons & their listeners
        Button s1 = song1.GetComponent<Button>();
        Button s2 = song2.GetComponent<Button>();
        Button s3 = song3.GetComponent<Button>();
        s1.onClick.AddListener(PickSong1);
        s2.onClick.AddListener(PickSong2);
        s3.onClick.AddListener(PickSong3);
    }

    void PickSong1()
    {
        // Set player and its line to visible
        player = playerContainer.transform.GetChild(0).gameObject;
        player.SetActive(true);
        line = GUI.transform.GetChild(3).gameObject;
        line.SetActive(true);

        // Pick appropriate song in MultipleAudio
        audioSource[0] = playerContainer.transform.GetChild(0).gameObject.GetComponent<MultipleAudio>();
        audioSource[1] = mainCamera.GetComponent<MultipleAudio>();
        audioSource[0].trackSelector = 0;
        audioSource[1].trackSelector = 0;
        audioSource[0].trackSelected = true;
        audioSource[1].trackSelected = true;

        // Hide song select panel
        songSelectPanel.SetActive(false);
    }

    void PickSong2()
    {
        // Set player and its line to visible
        player = playerContainer.transform.GetChild(0).gameObject;
        player.SetActive(true);
        line = GUI.transform.GetChild(3).gameObject;
        line.SetActive(true);

        // Pick appropriate song in MultipleAudio
        audioSource[0] = playerContainer.transform.GetChild(0).gameObject.GetComponent<MultipleAudio>();
        audioSource[1] = mainCamera.GetComponent<MultipleAudio>();
        audioSource[0].trackSelector = 1;
        audioSource[1].trackSelector = 1;
        audioSource[0].trackSelected = true;
        audioSource[1].trackSelected = true;

        // Hide song select panel
        songSelectPanel.SetActive(false);
    }

    void PickSong3()
    {
        // Set player and its line to visible
        player = playerContainer.transform.GetChild(0).gameObject;
        player.SetActive(true);
        line = GUI.transform.GetChild(3).gameObject;
        line.SetActive(true);

        // Pick appropriate song in MultipleAudio
        audioSource[0] = playerContainer.transform.GetChild(0).gameObject.GetComponent<MultipleAudio>();
        audioSource[1] = mainCamera.GetComponent<MultipleAudio>();
        audioSource[0].trackSelector = 2;
        audioSource[1].trackSelector = 2;
        audioSource[0].trackSelected = true;
        audioSource[1].trackSelected = true;

        // Hide song select panel
        songSelectPanel.SetActive(false);
    }
}
