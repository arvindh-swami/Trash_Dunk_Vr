using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSkulls : MonoBehaviour {

    public GameObject SkullPrefab;
    private bool gameOver;
    public GameObject gameOverObject;
    float time;

    public AudioClip throwskull;
    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        gameOver = false;
        //this.GetComponent<Renderer>().material.color.a = 0.5f;
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        float t = Time.timeSinceLevelLoad;
        string minutes = ((int)t / 60).ToString();
        if (minutes.Equals("1"))
            gameOver = true;
        if (Input.GetKeyDown("space") && !gameOver && ((Time.time - time) >= 1f))
        {
            GameObject.Instantiate(SkullPrefab, this.transform.position, Quaternion.identity);
            time = Time.time;
            audioSource.PlayOneShot(throwskull, 1F);
        }
        if (gameOver)
        {
            gameOverObject.SetActive(true);
        }
	}
}
