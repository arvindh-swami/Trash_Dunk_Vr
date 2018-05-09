using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour {

    private bool gameOver;
    // Use this for initialization
    public TextMesh timerText;

	void Start () {
        gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
        float t = Time.timeSinceLevelLoad;
        string minutes = ((int)t / 60).ToString();
        string seconds = (60 - (t % 60)).ToString("f2");
        if (minutes.Equals("1"))
            gameOver = true;
        if (gameOver)
            timerText.text = ""; // Used to be: timerText.text = "Time Left:\n  0:0.00";
        else
            timerText.text = "Time Left:\n  " + minutes + ":" + seconds;
    }
}
