using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class does the necessary calculations to figure out
 * whether an obstacle has been hit and triggers the appropriate
 * animations/score tallying functions based on the accuracy of
 * the hit. 
 */

public class CheckScore : MonoBehaviour {

    // Public constants
    public float perfectRange = 0.5f;
    public float goodRange = 0.8f;

    // Score Animators
    Animator perfectAnimator;
    Animator goodAnimator;
    Animator badAnimator;

    // Misc
    ScoreTally scoretally;
    ScoreGame scoreGame;

    // Init
    void Start () {
        scoretally = GameObject.Find("Canvas/Score Panel/Score Text").GetComponent<ScoreTally>();
        perfectAnimator = GameObject.Find("perfect note").GetComponent<Animator>();
        goodAnimator = GameObject.Find("good note").GetComponent<Animator>();
        badAnimator = GameObject.Find("bad note").GetComponent<Animator>();
        scoreGame = GameObject.Find("Player Container").transform.GetChild(0).GetComponent<ScoreGame>();
    }

    // When obstacle is hit by player
    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject contactObject = collider.gameObject;

        // Figures out whether obstacle has already been attempted
        bool hitBefore = contactObject.GetComponent<Hit>().hasBeenHit;

        if (!hitBefore && !scoreGame.gameOver)
        {
            float distance = Mathf.Abs(transform.position.x - contactObject.transform.position.x);
            if (distance <= perfectRange)
            {
                scoretally.perfectScore();
                perfectAnimator.SetTrigger("perfect");
            }
            else if (distance <= goodRange)
            {
                scoretally.goodScore();
                goodAnimator.SetTrigger("good");
            }
            else
            {
                badAnimator.SetTrigger("bad");
            }
            contactObject.GetComponent<Hit>().hasBeenHit = true;
        }
        
    }
}
