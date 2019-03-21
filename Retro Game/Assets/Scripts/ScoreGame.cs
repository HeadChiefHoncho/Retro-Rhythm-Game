using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGame : MonoBehaviour {

    public ScoreTally scoreTally;
    public AudioSource audioSource;
    private int score = 0;
    private string scoreString;
    public Text lowScoreText;
    public Text highScoreText;
    public GameObject scorePanel;
    GameObject canvas;
    PauseButtonHandler pauseButton;
    float timeDone = float.MaxValue;
    public float minTimeDone = 2f;
    private MultipleAudio multipleAudio;
    public bool gameOver = false;
    private GameObject player;


    // Use this for initialization
    void Start () {
        canvas = GameObject.Find("Canvas");
        player = GameObject.Find("Player Container").transform.GetChild(0).gameObject;

        multipleAudio = player.GetComponent<MultipleAudio>();
        pauseButton = canvas.GetComponent<PauseButtonHandler>();
        audioSource = player.GetComponent<AudioSource>();
        scoreTally = GameObject.Find("Canvas/Score Panel/Score Text").GetComponent<ScoreTally>();
        
        lowScoreText.text = getText(score);
        highScoreText.text = getText(score);
        
    }
	
	// Update is called once per frame
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
            //pauseButton.pause = false;
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
