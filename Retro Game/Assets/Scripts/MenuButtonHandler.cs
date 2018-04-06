using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtonHandler : MonoBehaviour {

    public Button howToPlay;
    public Button startGame;
    public Button exitGame;
    public Button exitTutorial;
    public GameObject tutorialPanel;
    public GameObject canvas;

    // Use this for initialization
    void Start () {

        canvas = GameObject.Find("Canvas");
        tutorialPanel = canvas.transform.GetChild(3).gameObject;
        tutorialPanel.SetActive(false);

        Button htp = howToPlay.GetComponent<Button>();
        Button sg = startGame.GetComponent<Button>();
        Button eg = exitGame.GetComponent<Button>();
        Button et = exitTutorial.GetComponent<Button>();

        sg.onClick.AddListener(StartGame);
        eg.onClick.AddListener(ExitGame);
        htp.onClick.AddListener(OpenTutorial);
        et.onClick.AddListener(CloseTutorial);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void StartGame()
    {
        SceneManager.LoadScene("game");
    }

    void ExitGame()
    {
        Application.Quit();
    }
 
    void OpenTutorial()
    {
        tutorialPanel = canvas.transform.GetChild(3).gameObject;
        tutorialPanel.SetActive(true);
    }

    void CloseTutorial()
    {
        tutorialPanel = canvas.transform.GetChild(3).gameObject;
        tutorialPanel.SetActive(false);
    }

}
