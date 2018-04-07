using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LowScoreHandler : MonoBehaviour {

    public Button retry;
    public Button mainMenu;
    public GameObject lowScorePanel;
    public GameObject canvas;
    public MicInput micInput;
    public MultipleAudio[] audioSource;

    // Use this for initialization
    void Start () {
        canvas = GameObject.Find("Canvas");
        lowScorePanel = canvas.transform.GetChild(4).gameObject;
        lowScorePanel.SetActive(false);

        Button ret = retry.GetComponent<Button>();
        Button mm = mainMenu.GetComponent<Button>();

        mm.onClick.AddListener(ExitGame);
        ret.onClick.AddListener(StartGame);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void StartGame()
    {
        micInput.startedGame = false;
        audioSource[0].trackSelected = false;
        audioSource[1].trackSelected = false;
        SceneManager.LoadScene("game");
    }

    void ExitGame()
    {
        micInput.startedGame = false;
        audioSource[0].trackSelected = false;
        audioSource[1].trackSelected = false;
        SceneManager.LoadScene("menu");
    }
}
