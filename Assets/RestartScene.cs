using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour {

	[SerializeField] private string loadLevel;
    [SerializeField] private string loadMenu;
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			SceneManager.LoadScene (loadLevel);
			Debug.Log ("Pressed Up Arrow");
		} 

		else if (Input.GetKeyDown (KeyCode.DownArrow)) 
		{
            SceneManager.LoadScene(loadMenu);
            Debug.Log("Pressed Up Arrow");
        }
	}
}