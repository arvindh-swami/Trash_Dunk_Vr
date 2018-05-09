using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScene : MonoBehaviour {

	[SerializeField] private string loadLevelone;
    [SerializeField] private string loadLeveltwo;
    [SerializeField] private string loadLevelthree;
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) 
		{
            SceneManager.LoadScene (loadLevelone);
			Debug.Log ("Pressed 1 -> will load level 1");
		}

        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            SceneManager.LoadScene (loadLeveltwo);
            Debug.Log("Pressed 2 -> will load level 2");
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            SceneManager.LoadScene (loadLevelthree);
            Debug.Log("Pressed 3 -> will load level 3");
        }

        else if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Debug.Log ("Pressed Escape -> will quit the game");
			Application.Quit ();
		}
	}
}