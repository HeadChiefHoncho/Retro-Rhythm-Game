using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreHandler : MonoBehaviour {

    // Canvas/Panels
    public GameObject highScorePanel;
    public GameObject canvas;

    // Panel Components
    public Button submitButton;
    public Text nameText;
    public Text highScoreText;

    // Pause Button Handler - to exit game
    public PauseButtonHandler pauseButtonHandler;

    // PlayerPrefs constants
    const string HS_NAME_1 = "high_score_name_1";
    const string HS_NAME_2 = "high_score_name_2";
    const string HS_NAME_3 = "high_score_name_3";
    const string HS_INT_1 = "high_score_int_1";
    const string HS_INT_2 = "high_score_int_2";
    const string HS_INT_3 = "high_score_int_3";

    // Score Tally instance to grab score
    public ScoreTally scoreTally;

    void Start () {
        // Set up canvas & high score panel
        canvas = GameObject.Find("Canvas");
        highScorePanel = canvas.transform.GetChild(3).gameObject;
        highScorePanel.SetActive(false);

        // Add submit button listener
        Button submit = submitButton.GetComponent<Button>();
        submit.onClick.AddListener(onSubmit);
    }

    // Submit Button Handler
    void onSubmit()
    {
        // Grab name and score
        string name = nameText.text;
        int score = scoreTally.scoreValue;

        // Load high scores
        int hs1 = PlayerPrefs.GetInt(HS_INT_1, 0);
        int hs2 = PlayerPrefs.GetInt(HS_INT_2, 0);
        PlayerPrefs.GetInt(HS_INT_3, 0);
        string hsn1 = PlayerPrefs.GetString(HS_NAME_1, "none");
        string hsn2 = PlayerPrefs.GetString(HS_NAME_2, "none");
        PlayerPrefs.GetString(HS_NAME_3, "none");

        if (score >= hs1) // new highest score!
        {
            // bump down hs2 to hs3
            PlayerPrefs.SetString(HS_NAME_3, hsn2);
            PlayerPrefs.SetInt(HS_INT_3, hs2);

            // bump down hs1 to hs2
            PlayerPrefs.SetString(HS_NAME_2, hsn1);
            PlayerPrefs.SetInt(HS_INT_2, hs1);

            // set hs1 to new high score
            PlayerPrefs.SetString(HS_NAME_1, name);
            PlayerPrefs.SetInt(HS_INT_1, score);

        } else if (score >= hs2) // new 2nd highest score!
        {
            // bump down hs2 to hs3
            PlayerPrefs.SetString(HS_NAME_3, hsn2);
            PlayerPrefs.SetInt(HS_INT_3, hs2);

            // set hs2 to new high score
            PlayerPrefs.SetString(HS_NAME_2, name);
            PlayerPrefs.SetInt(HS_INT_2, score);
        }
        else // new 3rd highest score!
        {
            // set hs3 to new high score
            PlayerPrefs.SetString(HS_NAME_3, name);
            PlayerPrefs.SetInt(HS_INT_3, score);
        }

        // Save new high scores
        PlayerPrefs.Save();

        // Exit to main menu and reset game state
        pauseButtonHandler.ExitGame();
    }
}
