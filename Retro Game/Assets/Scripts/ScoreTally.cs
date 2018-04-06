using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTally : MonoBehaviour {

    public Text scoreText;
    public int scoreValue = 0;

	// Use this for initialization
	void Start () {
        scoreText.text = getText(scoreValue);
    }
	
	// Update is called once per frame
	void Update () {
        scoreText.text = getText(scoreValue);
    }

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
