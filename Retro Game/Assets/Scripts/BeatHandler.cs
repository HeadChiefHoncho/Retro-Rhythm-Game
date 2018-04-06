using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatHandler : MonoBehaviour {

    public bool activated = false;
    GameObject above;
    GameObject below;
    GameObject aboveEnd;
    GameObject belowEnd;
    Vector3 aboveOrig;
    Vector3 belowOrig;
    public Vector2 obstacleSpeed = new Vector2(-2, 0); // based on tiles on screen
    float lastBeat;
    public float cooldown = 0.1f;
    bool needsBeat = true;
    PauseButtonHandler pauseButton;

    // Use this for initialization
    void Start () {
        pauseButton = GameObject.Find("Canvas").GetComponent<PauseButtonHandler>();

        //Select the instance of AudioProcessor and pass a reference
        //to this object
        AudioProcessor processor = FindObjectOfType<AudioProcessor>();
        processor.onBeat.AddListener(onOnbeatDetected);
        processor.onSpectrum.AddListener(onSpectrum);

        // Get origin positions of obstacles for copying
        above = GameObject.Find("above");
        aboveOrig = above.transform.position;
        below = GameObject.Find("below");
        belowOrig = below.transform.position;
        aboveEnd = GameObject.Find("above end");
        belowEnd = GameObject.Find("below end");

        // set end obstacles for colliding and deleting to be same as originals
        aboveEnd.transform.position = new Vector3(-aboveOrig.x - 3, aboveOrig.y, 0);
        belowEnd.transform.position = new Vector3(-belowOrig.x - 3, belowOrig.y, 0);
    }
	
	// Update is called once per frame
	void Update () {

    }

    //this event will be called every time a beat is detected.
    //Change the threshold parameter in the inspector
    //to adjust the sensitivity
    void onOnbeatDetected()
    {
        
        if (!needsBeat && ((Time.time - cooldown) >= lastBeat))
        {
            needsBeat = true;
        }
        if (needsBeat && !pauseButton.pause)
        {
            lastBeat = Time.time;
            needsBeat = false;
            GameObject newObstacle;
            float random = Random.Range(0.0f, 1.0f);

            // Obstacle has 50/50 chance of being above or below
            if (random >= 0.5f)
            {
                newObstacle = (GameObject)Instantiate(below);
                newObstacle.GetComponent<Rigidbody2D>().velocity = obstacleSpeed;
            }
            else
            {
                newObstacle = (GameObject)Instantiate(above);
                newObstacle.GetComponent<Rigidbody2D>().velocity = obstacleSpeed;
            }
        }
        
    }

    //This event will be called every frame while music is playing
    void onSpectrum(float[] spectrum)
    {
        //The spectrum is logarithmically averaged
        //to 12 bands

        for (int i = 0; i < spectrum.Length; ++i)
        {
            Vector3 start = new Vector3(i, 0, 0);
            Vector3 end = new Vector3(i, spectrum[i], 0);
            Debug.DrawLine(start, end);
        }
    }
}
