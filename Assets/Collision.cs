using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

    public TextMesh scoreText;
    public TextMesh highscoreText;
    private int score;
    private int highScore;
    private bool gameOver;
    public bool moveCan;
    public bool moveFan;
    public bool oscillateCan;
    public int fanForce;
    float time;
    int oscillateLength;
    public TextMesh windSpeedText;

    public AudioClip scoreSound;
    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        score = 0;
        DontDestroyOnLoad(this);
        if (moveCan)
            highScore = PlayerPrefs.GetInt("highScore1");
        else if (moveFan)
            highScore = PlayerPrefs.GetInt("highScore2");
        else
            highScore = PlayerPrefs.GetInt("highScore3");
        highscoreText.text = "High Score: " + highScore;
        time = 0f;
        if (moveFan)
        {
            fanForce = Random.Range(3, 9);
            PlayerPrefs.SetInt("fanForce", fanForce);
            PlayerPrefs.Save();
            windSpeedText.text = "Wind Speed: " + fanForce;
        }
        
        if (oscillateCan)
            oscillateLength = 5;
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        float t = Time.timeSinceLevelLoad;
        string minutes = ((int)t / 60).ToString();
        if (minutes.Equals("1")) 
            gameOver = true;
        if (score > highScore)
        {
            highScore = score;
            highscoreText.text = "High Score: " + highScore;
            if (moveCan)
                PlayerPrefs.SetInt("highScore1", highScore);
            else if (moveFan)
                PlayerPrefs.SetInt("highScore2", highScore);
            else
                PlayerPrefs.SetInt("highScore3", highScore);
            PlayerPrefs.Save();
            
        }
        if (oscillateCan)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.PingPong(Time.time, oscillateLength));
        }
        if (gameOver)
            windSpeedText.text = "";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "skull")
        {
            Destroy(other.gameObject);
            score++;
            scoreText.text = "Current Score: " + score;
            audioSource.PlayOneShot(scoreSound, 1F);

            if (moveFan)
            {
                fanForce = Random.Range(3, 9);
                PlayerPrefs.SetInt("fanForce", fanForce);
                PlayerPrefs.Save();
                windSpeedText.text = "Wind Speed: " + fanForce;
                GameObject fan = GameObject.FindGameObjectWithTag("fan");
                if (fan.transform.position.z < 3)
                {
                    fan.transform.position = new Vector3(-0.61f, 1.145f, 4.4f);
                    fan.transform.Rotate(0, 180f, 0);
                    time = Time.time;
                }
                else
                {
                    fan.transform.position = new Vector3(-0.61f, 1.145f, 1.139f);
                    fan.transform.Rotate(0, 180f, 0);
                    time = Time.time;
                }
            }
            //if (oscillateCan)
                //oscillateLength = Random.Range(2, 8);
        }
        if (moveCan)
        {
            int num = Random.Range(0, 4);
            if (num == 0)
                this.transform.position = new Vector3(-1.57f, 0, 2.685f);
            else if (num == 1)
                this.transform.position = new Vector3(1.43f, 0, -1.33f);
            else if (num == 2)
                this.transform.position = new Vector3(1.5f, 0, 5.5f);
            else if (num == 3)
                this.transform.position = new Vector3(-0.776f, 1.148f, 4.606f);
            else if (num == 4)
                this.transform.position = new Vector3(-1.394f, 1.148f, .874f);
        }
    }

    private void OnDestroy()
    {
        if (moveCan)
            PlayerPrefs.SetInt("highScore1", highScore);
        else if (moveFan)
            PlayerPrefs.SetInt("highScore2", highScore);
        else
            PlayerPrefs.SetInt("highScore3", highScore);
        PlayerPrefs.Save();
    }

    public float getFanForce()
    {
        return fanForce;
    }
}
