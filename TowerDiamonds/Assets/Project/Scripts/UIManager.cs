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
	public GameObject speedUpButton;
	[HideInInspector]
	public Animator speedUpAnimator;
	private Image pauseButtonImage;
	private Sprite pauseSprite;
	public Sprite playSprite;
	private bool gameOverOn = false;

	void Start () {	
		pauseButtonImage = pauseButton.GetComponent<Image> ();
		pauseSprite = pauseButtonImage.sprite;
		speedUpAnimator = speedUpButton.GetComponent<Animator> ();
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
		if (gameOverOn) {
			return;
		}
		towerShop.gameObject.SetActive (true);
	}

	public void EnableTowerDetails () {
		DisableUI ();
		if (gameOverOn) {
			return;
		}
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

	public void EnableSpeedUpAnimation () {
			speedUpAnimator.enabled = true;
	}

	public void DisableSpeedUpAnimation () {
			speedUpAnimator.enabled = false;
	}

	public void EnableComplete () {
		DisableUI ();
		complete.gameObject.SetActive (true);
		pauseButton.gameObject.SetActive (false);
		gameOverOn = true;
	}

	public void EnableGameOver () {
		DisableUI ();
		gameOver.gameObject.SetActive (true);
		pauseButton.gameObject.SetActive (false);
		speedUpButton.gameObject.SetActive (false);
		gameOverOn = true;
	}
}