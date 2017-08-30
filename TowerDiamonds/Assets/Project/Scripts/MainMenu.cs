//by Niklas Bachmann
//14.08.2017

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void ChooseTutorial () {
		SceneManager.LoadScene (1);
	}		

	public void ChooseKampagne () {
		SceneManager.LoadScene (1);
	}

	public void ChooseEndless () {
		SceneManager.LoadScene (2);
	}

	public void ChooseSound () {
		//Sound on/off
		if (PlayerStats.sound) {
			PlayerStats.sound = false;
		} else {
			PlayerStats.sound = true;
		}
	}

	public void ChooseMusic () {
		//Music on/off
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