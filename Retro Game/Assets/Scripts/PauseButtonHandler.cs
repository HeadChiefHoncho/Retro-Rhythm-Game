using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 * This class implements the pause menu during gameplay.
 */

public class PauseButtonHandler : MonoBehaviour {

    // Pause Menu Buttons
    public Button menu;
    public Button resume;
    public Button restart;
    public Button mainMenu;

    // Canvas & Pause Menu
    public GameObject pausePanel;
    public GameObject canvas;

    // Audio Controls
    public MultipleAudio multipleAudio;
    public MicInput micInput;
    public MultipleAudio[] audioSource;
    public AudioSource music;

    // Misc
    public bool pause = false; // is game paused?
    public DelayAudio delayAudio;
    public ScoreGame scoreGame;

    void Start()
    {
        // Canvas/Menu setup (make invisible)
        canvas = GameObject.Find("Canvas");
        pausePanel = canvas.transform.GetChild(2).gameObject;
        pausePanel.SetActive(false);

        // Set up buttons
        Button m = menu.GetComponent<Button>();
        Button resu = resume.GetComponent<Button>();
        Button rest = restart.GetComponent<Button>();
        Button mm = mainMenu.GetComponent<Button>();

        // Set up listeners
        m.onClick.AddListener(OpenPause);
        resu.onClick.AddListener(ClosePause);
        rest.onClick.AddListener(StartGame);
        mm.onClick.AddListener(ExitGame);
    }

    void Update()
    {
        if (!scoreGame.gameOver && multipleAudio.trackSelected && micInput.startedGame)// && !delayAudioSelected)
        {
            delayAudio = GameObject.Find("player").GetComponent<DelayAudio>();
        }
    }

    // Restart Button Listener
    void StartGame()
    {
        // reset startedGame bool
        micInput.startedGame = false;

        // Reset tracks
        audioSource[0].trackSelected = false;
        audioSource[1].trackSelected = false;

        // Reload game
        SceneManager.LoadScene("game");
    }

    // Main Menu Button Listener
    public void ExitGame()
    {
        // Reset startedGame bool
        micInput.startedGame = false;

        // Reset tracks
        audioSource[0].trackSelected = false;
        audioSource[1].trackSelected = false;

        // Load menu
        SceneManager.LoadScene("menu");
    }

    // Menu Button Listener
    void OpenPause()
    {
        // Menu will only open if audio delay is complete and music is playing
        if (micInput.startedGame && delayAudio.delayDone && music.isPlaying)
        {
            // Opens pause panel and pauses game
            pausePanel = canvas.transform.GetChild(2).gameObject;
            pausePanel.SetActive(true);
            music.Pause();
            pause = true;
        }
    }

    // Resume Button Listener
    void ClosePause()
    {
        // Hides pause menu
        pausePanel = canvas.transform.GetChild(2).gameObject;
        pausePanel.SetActive(false);
        music.UnPause();

        // Resumes game
        pause = false;
    }
}
