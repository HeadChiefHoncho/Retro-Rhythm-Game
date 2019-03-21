using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 * This class implements the main menu of the game.
 */

public class MenuButtonHandler : MonoBehaviour {

    // Canvas/Panel Objects
    public GameObject tutorialPanel;
    public GameObject canvas;

    // Buttons
    public Button howToPlay;
    public Button startGame;
    public Button exitGame;
    public Button exitTutorial;
    

    void Start () {

        // Init Canvas/Panels
        canvas = GameObject.Find("Canvas");
        tutorialPanel = canvas.transform.GetChild(3).gameObject;
        tutorialPanel.SetActive(false);


        // Init Buttons/Assign Listeners
        Button htp = howToPlay.GetComponent<Button>();
        Button sg = startGame.GetComponent<Button>();
        Button eg = exitGame.GetComponent<Button>();
        Button et = exitTutorial.GetComponent<Button>();

        sg.onClick.AddListener(StartGame);
        eg.onClick.AddListener(ExitGame);
        htp.onClick.AddListener(OpenTutorial);
        et.onClick.AddListener(CloseTutorial);
	}

    // Starts a new game
    void StartGame()
    {
        SceneManager.LoadScene("game");
    }

    // Exits the application
    void ExitGame()
    {
        Application.Quit();
    }
 
    // Opens the tutorial pane
    void OpenTutorial()
    {
        tutorialPanel = canvas.transform.GetChild(3).gameObject;
        tutorialPanel.SetActive(true);
    }

    // Close the tutorial pane
    void CloseTutorial()
    {
        tutorialPanel = canvas.transform.GetChild(3).gameObject;
        tutorialPanel.SetActive(false);
    }

}
