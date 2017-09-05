//by Niklas Bachmann
//14.08.2017

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void ChooseTutorial () {
		SceneManager.LoadScene (1);
		Time.timeScale = 1.0f;
	}		

	public void ChooseKampagne () {
		SceneManager.LoadScene (1);
		Time.timeScale = 1.0f;
	}

	public void ChooseEndlessMap1 () {
		SceneManager.LoadScene (2);
		Time.timeScale = 1.0f;
	}

	public void ChooseEndlessMap2 () {
		SceneManager.LoadScene (3);
		Time.timeScale = 1.0f;
	}

	public void ChooseSound () {
		//Music on/off
		//Sound on/off
		if (PlayerStats.sound) {
			PlayerStats.sound = false;
		} else {
			PlayerStats.sound = true;
		}
	}

	public void ChooseMusic () {
		//Sound on/off
		if (PlayerStats.music) {
			PlayerStats.music = false;
		} else {
			PlayerStats.music = true;
		}
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}	
	}
}