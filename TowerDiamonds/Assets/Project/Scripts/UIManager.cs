//by Niklas Bachmann
//16.08.2017

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	
	[HideInInspector]
	public Socket selectedSocket;
	public Transform towerShop;
	public Transform towerDetails;
	public Transform towerDias;
	public Transform overallDias;
	public Transform gameOver;
	public Transform complete;
	public GameObject pauseButton;
	private Image pauseButtonImage;
	private Sprite pauseSprite;
	public Sprite playSprite;

	void Start () {	
		pauseButtonImage = pauseButton.GetComponent<Image> ();
		pauseSprite = pauseButtonImage.sprite;	
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
		selectedSocket.SetHoverColor ();
	}

	public void EnableOverallDias () {
		overallDias.gameObject.SetActive (true);
	}

	public void SwitchPauseButtonSprite () {
		if (pauseButtonImage.sprite == pauseSprite) {
			pauseButtonImage.sprite = playSprite;
		} else {
			pauseButtonImage.sprite = pauseSprite;
		}
	}

	public void SetSelectedSocket (Socket socket) {
		selectedSocket = socket;
	}

	public void EnableComplete () {
		complete.gameObject.SetActive (true);
	}
}