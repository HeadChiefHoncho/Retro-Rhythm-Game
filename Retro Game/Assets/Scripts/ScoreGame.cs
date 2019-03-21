using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * This class does the final score calculations to determine whether
 * a score is a new high score or not. It also keeps track of whether
 * a game has ended or not! (a set delay time after the song has finished
 * playing and the game is not paused)
 */

public class ScoreGame : MonoBehaviour {

    // Game Objects
    public AudioSource audioSource;
    public Text lowScoreText;
    public Text highScoreText;
    public GameObject scorePanel;
    GameObject canvas;
    private GameObject player;

    // Script Instances
    public ScoreTally scoreTally;
    PauseButtonHandler pauseButton;
    private MultipleAudio multipleAudio;

    // Constans and Booleans
    public float minTimeDone = 2f;
    public bool gameOver = false;
    private int score = 0;
    private string scoreString;
    private float timeDone = float.MaxValue;
    

    void Start () {
        // Game Object Setup
        canvas = GameObject.Find("Canvas");
        player = GameObject.Find("Player Container").transform.GetChild(0).gameObject;

        multipleAudio = player.GetComponent<MultipleAudio>();
        pauseButton = canvas.GetComponent<PauseButtonHandler>();
        audioSource = player.GetComponent<AudioSource>();
        scoreTally = GameObject.Find("Canvas/Score Panel/Score Text").GetComponent<ScoreTally>();
        
        // Grab score text
        lowScoreText.text = getText(score);
        highScoreText.text = getText(score);
        
    }
	
	void Update () {
        // Grabs the time the song actually finishes
        if (!pauseButton.pause && !audioSource.isPlaying && timeDone == float.MaxValue)
        {
            Debug.Log("Song finished!");
            Debug.Log("audiosource is playing: " + audioSource.isPlaying);
            Debug.Log("multiple audio track selected: " + multipleAudio.trackSelected);
            timeDone = Time.time;
            gameOver = true;
        }

        // Score the game and display the score panel minTimeDone seconds after the song ends
        if (gameOver && !audioSource.isPlaying && !pauseButton.pause && (Time.time - timeDone) >= minTimeDone)
        {
            Debug.Log("Display score panel");
            score = scoreTally.scoreValue;
            displayScore();
            gameOver = true;
            player = GameObject.Find("Player Container").transform.GetChild(0).gameObject;
            player.SetActive(false);
        }

        if (gameOver)
        {
            pauseButton.pause = false;
        }
	}

    void displayScore()
    {

        scoreString = getText(score);
        lowScoreText.text = scoreString;
        highScoreText.text = scoreString;

        // a check should be performed here as to whether the score is a new low score, or a new high score.
        bool newHighScore = checkScore();

        if (!newHighScore)
        {
            // Grabs final score panel, not new high score
            scorePanel = canvas.transform.GetChild(4).gameObject;
            scorePanel.SetActive(true);
        }
        else
        {
            scorePanel = canvas.transform.GetChild(3).gameObject;
            scorePanel.SetActive(true);
        }

    }

    string getText(int score)
    {
        string scoreString = score.ToString();
        string scoreText = "";

        // add spaces in between numbers of score to make font look better :/
        for (int i = 0; i < scoreString.Length; i++)
        {
            scoreText += (" " + scoreString[i]);
        }

        return scoreText.Substring(1);
    }

    bool checkScore()
    {
        // Returns true if score is a new high score.
        // do loading to check score against 3rd highest score
        return score >= PlayerPrefs.GetInt("high_score_int_3");
    }
}
