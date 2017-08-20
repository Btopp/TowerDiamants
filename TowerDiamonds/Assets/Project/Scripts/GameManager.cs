//by Niklas Bachmann
//19.08.2017

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	[HideInInspector]
	public bool pauseButtonPressed = false;

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			BackToMainMenu ();
		}			
	}

	public void BackToMainMenu () {
		SceneManager.LoadScene (0);
	}

	public void PauseGame () {
		Time.timeScale = 0f;
	}

	public void StartGame () {
		Time.timeScale = 1f;
	}

	public void PressPauseButton () {
			if (pauseButtonPressed) {
			StartGame ();
			pauseButtonPressed = false;
		} else {
			PauseGame ();
			pauseButtonPressed = true;
		}	
	}
}