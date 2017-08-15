//by Niklas Bachmann
//15.08.2017

using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour {

	public void BackToMainMenu () {
		SceneManager.LoadScene (0);
	}

}