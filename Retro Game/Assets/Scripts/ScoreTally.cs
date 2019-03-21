using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * This class changes the score based on the quality
 * of a player's hit. It is called by the CheckScore class,
 * which handles the animations for said hits.
 */

public class ScoreTally : MonoBehaviour {

    public Text scoreText;
    public int scoreValue = 0;

	void Start () {
        scoreText.text = getText(scoreValue);
    }
	
	void Update () {
        scoreText.text = getText(scoreValue);
    }


    // Score Functions

    public void perfectScore()
    {
        scoreValue += 10;
    }

    public void goodScore()
    {
        scoreValue += 5;
    }

    public void badScore()
    {
        scoreValue += 0;
    }


    // Returns score text formatted for display (w/ spaces added)
    string getText(int score)
    {
        string scoreString = score.ToString();
        string scoreText = "Score:  ";

        for (int i = 0; i < scoreString.Length; i++)
        {
            scoreText += (" " + scoreString[i]);
        }

        return scoreText;
    }
}
