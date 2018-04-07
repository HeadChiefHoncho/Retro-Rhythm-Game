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
    float timeDone = 0f;
    public float minTimeDone = 2f;
    private MultipleAudio multipleAudio;


    // Use this for initialization
    void Start () {
        multipleAudio = GameObject.Find("player").GetComponent<MultipleAudio>();
        pauseButton = GameObject.Find("Canvas").GetComponent<PauseButtonHandler>();
        audioSource = GameObject.Find("player").GetComponent<AudioSource>();
        scoreTally = GameObject.Find("Canvas/Score Panel/Score Text").GetComponent<ScoreTally>();
        canvas = GameObject.Find("Canvas");
        lowScoreText.text = getText(score);
        highScoreText.text = getText(score);
    }
	
	// Update is called once per frame
	void Update () {
        if (!audioSource.isPlaying || !multipleAudio.trackSelected)
        {
            timeDone = Time.time;
        }
        if (!audioSource.isPlaying && !pauseButton.pause && (Time.time - timeDone) >= minTimeDone)
        {
            score = scoreTally.scoreValue;
            displayScore();
            pauseButton.pause = false;
        }
	}

    void displayScore()
    {
        scoreString = getText(score);
        lowScoreText.text = scoreString;
        highScoreText.text = scoreString;

        // Grabs final score panel, not new high score
        scorePanel = canvas.transform.GetChild(4).gameObject;
        scorePanel.SetActive(true);
    }

    string getText(int score)
    {
        string scoreString = score.ToString();
        string scoreText = "";

        for (int i = 0; i < scoreString.Length; i++)
        {
            scoreText += (" " + scoreString[i]);
        }

        return scoreText.Substring(1);
    }
}
