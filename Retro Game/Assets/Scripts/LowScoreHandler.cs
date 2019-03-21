using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 * This class handles the low score (not high score) panel that
 * a player encounters when they do not obtain a new high score.
 * 
 * It gives the player the option to restart/retry, or to go to
 * the main menu.
 */

public class LowScoreHandler : MonoBehaviour {

    // Canvas and Panels
    public GameObject lowScorePanel;
    public GameObject canvas;

    // Buttons
    public Button retry;
    public Button mainMenu;
    
    // Misc
    public MicInput micInput;
    public MultipleAudio[] audioSource;

    void Start () {
        // Canvas/Panel Init
        canvas = GameObject.Find("Canvas");
        lowScorePanel = canvas.transform.GetChild(4).gameObject;
        lowScorePanel.SetActive(false);

        // Button and Listener Init
        Button ret = retry.GetComponent<Button>();
        Button mm = mainMenu.GetComponent<Button>();
        mm.onClick.AddListener(ExitGame);
        ret.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        // Reset game state
        micInput.startedGame = false;

        // Reset music tracks
        audioSource[0].trackSelected = false;
        audioSource[1].trackSelected = false;

        // Reload game
        SceneManager.LoadScene("game");
    }

    void ExitGame()
    {
        // Reset game state
        micInput.startedGame = false;

        // Reset music tracks
        audioSource[0].trackSelected = false;
        audioSource[1].trackSelected = false;

        // Reload main menu
        SceneManager.LoadScene("menu");
    }
}
