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
		SceneManager.LoadScene (1);
	}

	public void ChooseSound () {

		//Sound on/off

	}

	public void ChooseMusic () {

		//Music on/off

	}
}