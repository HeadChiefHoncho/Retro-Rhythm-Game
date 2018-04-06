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

    // Use this for initialization
    void Start()
    {

        canvas = GameObject.Find("Canvas");
        delayAudio = GameObject.Find("player").GetComponent<DelayAudio>();
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

    }

    void StartGame()
    {
        SceneManager.LoadScene("game");
    }

    void ExitGame()
    {
        SceneManager.LoadScene("menu");
    }

    void OpenPause()
    {
        if (delayAudio.delayDone)
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
