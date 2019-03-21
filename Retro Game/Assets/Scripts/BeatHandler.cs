using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatHandler : MonoBehaviour {

    
    public float cooldown = 0.8f;
    public Vector2 obstacleSpeed = new Vector2(-2, 0); // based on tiles on screen
    public bool activated = false;

    PauseButtonHandler pauseButton;
    GameObject above;
    GameObject below;
    GameObject aboveEnd;
    GameObject belowEnd;
    Vector3 aboveOrig;
    Vector3 belowOrig;
    
    float lastBeat;
    bool needsBeat = true;

    void Start () {
        pauseButton = GameObject.Find("Canvas").GetComponent<PauseButtonHandler>();

        // Set up audio processor and listener
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

    // Called every time a beat is detected
    void onOnbeatDetected()
    {
        // if we detect a beat but it has been too soon since last beat
        if (!needsBeat && ((Time.time - cooldown) >= lastBeat))
        {
            needsBeat = true;
        }

        // if there hasn't been a beat in a bit, and we're not paused, find another beat
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

    // Called every frame while music is playing
    void onSpectrum(float[] spectrum)
    {
        for (int i = 0; i < spectrum.Length; ++i)
        {
            Vector3 start = new Vector3(i, 0, 0);
            Vector3 end = new Vector3(i, spectrum[i], 0);
            Debug.DrawLine(start, end);
        }
    }
}
