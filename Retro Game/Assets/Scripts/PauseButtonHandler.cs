using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButtonHandler : MonoBehaviour {

    public Button menu;
    public Button resume;
    public Button restart;
    public Button mainMenu;
    public GameObject pausePanel;
    public GameObject canvas;
    public bool pause = false;
    DelayAudio delayAudio;
    public MultipleAudio multipleAudio;
    public MicInput micInput;
    public MultipleAudio[] audioSource;
    public AudioSource music;

    // Use this for initialization
    void Start()
    {

        canvas = GameObject.Find("Canvas");
        pausePanel = canvas.transform.GetChild(2).gameObject;
        pausePanel.SetActive(false);

        Button m = menu.GetComponent<Button>();
        Button resu = resume.GetComponent<Button>();
        Button rest = restart.GetComponent<Button>();
        Button mm = mainMenu.GetComponent<Button>();

        m.onClick.AddListener(OpenPause);
        resu.onClick.AddListener(ClosePause);
        rest.onClick.AddListener(StartGame);
        mm.onClick.AddListener(ExitGame);
    }

    // Update is called once per frame
    void Update()
    {
        if (multipleAudio.trackSelected && micInput.startedGame)
        {
            delayAudio = GameObject.Find("player").GetComponent<DelayAudio>();
        }
    }

    void StartGame()
    {
        micInput.startedGame = false;
        audioSource[0].trackSelected = false;
        audioSource[1].trackSelected = false;
        SceneManager.LoadScene("game");
    }

    void ExitGame()
    {
        micInput.startedGame = false;
        audioSource[0].trackSelected = false;
        audioSource[1].trackSelected = false;
        SceneManager.LoadScene("menu");
    }

    void OpenPause()
    {
        if (micInput.startedGame && delayAudio.delayDone && music.isPlaying)
        {
            pausePanel = canvas.transform.GetChild(2).gameObject;
            pausePanel.SetActive(true);
            pause = true;
        }
    }

    void ClosePause()
    {
        pausePanel = canvas.transform.GetChild(2).gameObject;
        pausePanel.SetActive(false);
        pause = false;
    }
}
