using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardHandler : MonoBehaviour {

    // PlayerPrefs constants
    const string HS_NAME_1 = "high_score_name_1";
    const string HS_NAME_2 = "high_score_name_2";
    const string HS_NAME_3 = "high_score_name_3";
    const string HS_INT_1 = "high_score_int_1";
    const string HS_INT_2 = "high_score_int_2";
    const string HS_INT_3 = "high_score_int_3";

    // Canvas/Panels
    public GameObject scoreboardPanel;
    public GameObject canvas;

    // Buttons
    public Button scoreboardButton;
    public Button exitScoreboardButton;

    // High Score Texts
    public Text hsText1;
    public Text hsText2;
    public Text hsText3;

    // Menu State booleans
    public bool displayScoreboard = false;

    // Score Strings
    string hs_text_1;
    string hs_text_2;
    string hs_text_3;

    void Start () {

        // Initialize canvas and scoreboard
        canvas = GameObject.Find("Canvas");
        scoreboardPanel = canvas.transform.GetChild(2).gameObject;
        scoreboardPanel.SetActive(false);

        // Set default high score values if necessary
        GetScores();

        // Set up button listeners
        Button scoreboard = scoreboardButton.GetComponent<Button>();
        Button exitScoreboard = exitScoreboardButton.GetComponent<Button>();
        scoreboard.onClick.AddListener(EnterScoreboard);
        exitScoreboard.onClick.AddListener(ExitScoreboard);

        // Set starting high score text values
        hsText1.text = hs_text_1;
        hsText2.text = hs_text_2;
        hsText3.text = hs_text_3;

        // TODO: make button handlers for scoreboard work
        //       make sure that the scoreboard is populated w/ the correct scores
        //       edit the ScoreGame file to make sure that a new high score is not ALWAYS being added (which it is right now for testing) 
    }

    void EnterScoreboard()
    {
        Debug.Log("scoreboard opened");

        GetScores();

        scoreboardPanel = canvas.transform.GetChild(2).gameObject;
        scoreboardPanel.SetActive(true);
    }

    void ExitScoreboard()
    {
        scoreboardPanel = canvas.transform.GetChild(2).gameObject;
        scoreboardPanel.SetActive(false);
    }

    void GetScores()
    {
        hs_text_1 = PlayerPrefs.GetString(HS_NAME_1, "none") + "  " + PlayerPrefs.GetInt(HS_INT_1, 0);
        hs_text_2 = PlayerPrefs.GetString(HS_NAME_2, "none") + "  " + PlayerPrefs.GetInt(HS_INT_2, 0);
        hs_text_3 = PlayerPrefs.GetString(HS_NAME_3, "none") + "  " + PlayerPrefs.GetInt(HS_INT_3, 0);
    }
}
