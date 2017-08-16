//by Niklas Bachmann
//16.08.2017

using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	public Transform towerShop;
	public Transform towerDetails;
	public Transform towerDias;
	public Transform overallDias;

	// muss in GameManager
	public void BackToMainMenu () {
		SceneManager.LoadScene (0);
	}		

	public void DisableUI () {
		towerShop.gameObject.SetActive (false);
		towerDetails.gameObject.SetActive (false);
		towerDias.gameObject.SetActive (false);
		overallDias.gameObject.SetActive (false);	
	}

	public void DisableOverallDias () {
		overallDias.gameObject.SetActive (false);	
	}

	public void EnableTowerShop () {
		DisableUI ();
		towerShop.gameObject.SetActive (true);
	}

	public void EnableTowerDetails () {
		DisableUI ();
		towerDetails.gameObject.SetActive (true);
	}

	public void EnableTowerDias () {
		DisableUI ();
		towerDias.gameObject.SetActive (true);
	}

	public void EnableOverallDias () {
		overallDias.gameObject.SetActive (true);
	}
}