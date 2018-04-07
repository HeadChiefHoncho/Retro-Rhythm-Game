using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScore : MonoBehaviour {

    ScoreTally scoretally;
    public float perfectRange = 0.5f;
    public float goodRange = 0.8f;
    Animator perfectAnimator;
    Animator goodAnimator;
    Animator badAnimator;

	// Use this for initialization
	void Start () {
        scoretally = GameObject.Find("Canvas/Score Panel/Score Text").GetComponent<ScoreTally>();
        perfectAnimator = GameObject.Find("perfect note").GetComponent<Animator>();
        goodAnimator = GameObject.Find("good note").GetComponent<Animator>();
        badAnimator = GameObject.Find("bad note").GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        //scoretally.perfectScore();
	}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject contactObject = collider.gameObject;
        bool hitBefore = contactObject.GetComponent<Hit>().hasBeenHit;
        if (!hitBefore)
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
