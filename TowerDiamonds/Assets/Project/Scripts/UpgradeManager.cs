//by Niklas Bachmann
//16.08.2017

using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour {

	public GameObject slotOne;
	public GameObject slotTwo;
	public GameObject slotThree;

	private Image slotOneImage;
	private Image slotTwoImage;
	private Image slotThreeImage;

	private GameObject selectedSlot;
	private Image selectedSlotImage;

	public Sprite diaDefault;
	public Sprite diaBlue;
	public Sprite diaGreen;
	public Sprite diaRed;

	private GameObject selectedTower;

	private UIManager uIManager;

	private ToastMessageScript toastMessageScript;

	void Start () {
		toastMessageScript = GameObject.Find ("MASTER").GetComponent<ToastMessageScript> ();
		uIManager = (UIManager) GameObject.Find("UIManager").GetComponent<UIManager> ();
		slotOneImage = slotOne.GetComponent<Image> ();
		slotTwoImage = slotTwo.GetComponent<Image> ();
		slotThreeImage = slotThree.GetComponent<Image> ();
	}

	public void SelectSlotOne () {
		selectedSlot = slotOne;
		UpdateSlotSprite ();
	}

	public void SelectSlotTwo () {
		selectedSlot = slotTwo;
		UpdateSlotSprite ();
	}

	public void SelectSlotThree () {
		selectedSlot = slotThree;
		UpdateSlotSprite ();
	}

	public void SelectDiamondBlue () {
		if (selectedSlotImage.sprite != diaDefault) {
			Debug.Log ("Socket is used");	
		} else {
			if (PlayerStats.blueDiasToUse <= 0) {
				toastMessageScript.showToastOnUiThread ("No Blue Diamonds!");
				return;
			}
			selectedSlotImage.sprite = diaBlue;
			selectedTower.GetComponent<Tower>().SetSlow();
			SaveSlots ();
			PlayerStats.SubDiamondsToUse (1, 1);
		}
		uIManager.DisableOverallDias ();
	}

	public void SelectDiamondGreen () {
		if (selectedSlotImage.sprite != diaDefault) {
			Debug.Log ("Socket is used");	
		} else {
			if (PlayerStats.greenDiasToUse <= 0) {
				toastMessageScript.showToastOnUiThread ("No Green Diamonds!");
				return;
			}
			selectedSlotImage.sprite = diaGreen;
			selectedTower.GetComponent<Tower>().SetRange();
			SaveSlots ();
			PlayerStats.SubDiamondsToUse (2, 1);
		}
		uIManager.DisableOverallDias ();
	}

	public void SelectDiamondRed () {
		if (selectedSlotImage.sprite != diaDefault) {
			Debug.Log ("Socket is used");	
		} else {
			if (PlayerStats.redDiasToUse <= 0) {
				toastMessageScript.showToastOnUiThread ("No Red Diamonds!");
				return;
			}
			selectedSlotImage.sprite = diaRed;
			selectedTower.GetComponent<Tower>().SetDamage();
			SaveSlots ();
			PlayerStats.SubDiamondsToUse (3, 1);
		}
		uIManager.DisableOverallDias ();
	}

	public void SetSelectedTower (GameObject tower) {
		selectedTower = tower;
	}

	public void SetSlotSprites (){
		Sprite towerSlot1Sprite = selectedTower.GetComponent<TowerUpgrade> ().slotOneSprite;
		Sprite towerSlot2Sprite = selectedTower.GetComponent<TowerUpgrade> ().slotTwoSprite;
		Sprite towerSlot3Sprite = selectedTower.GetComponent<TowerUpgrade> ().slotThreeSprite;
		if (towerSlot1Sprite != null) {
			slotOneImage.sprite = towerSlot1Sprite;
		} else {
			slotOneImage.sprite = diaDefault;
		}
		if (towerSlot2Sprite != null) {
			slotTwoImage.sprite = towerSlot2Sprite;
		} else {
			slotTwoImage.sprite = diaDefault;
		}
		if (towerSlot3Sprite != null) {
			slotThreeImage.sprite = towerSlot3Sprite;
		} else {
			slotThreeImage.sprite = diaDefault;
		}
	}

	public void SaveSlots (){
		selectedTower.GetComponent<TowerUpgrade> ().SaveSlots (slotOneImage.sprite, slotTwoImage.sprite, slotThreeImage.sprite);
	}

	public void UpdateSlotSprite () {
		selectedSlotImage = selectedSlot.GetComponent<Image> ();
	}
		
	public void DeleteSelectedTower () {
		PlayerStats.AddEnergy ((int) Mathf.Floor (0.6f * selectedTower.GetComponent<Tower>().sellValue));
		Destroy (selectedTower);
		uIManager.DisableUI ();
	}
}