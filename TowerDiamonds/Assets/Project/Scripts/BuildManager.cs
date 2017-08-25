//by Niklas Bachmann
//10.08.2017

using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;

	public GameObject buildEffect;

	public GameObject squareTowerPrefab;
	public GameObject hexaTowerPrefab;
	public GameObject circTowerPrefab;

	private TowerBlueprint towerToBuild;
	[HideInInspector]
	public Socket socketToBuildOn;

	private UIManager uIManager;

	private ToastMessageScript toastMessageScript;

	void Awake () {
		if (instance != null) {
			return;
		}
		instance = this;
	}

	void Start () {
		toastMessageScript = GameObject.Find ("MASTER").GetComponent<ToastMessageScript> ();
		uIManager = (UIManager) GameObject.Find("UIManager").GetComponent<UIManager> ();
	}

	public void SelectTowerToBuild (TowerBlueprint tower) {
		towerToBuild = tower;
	}

	public void SelectSocketToBuildOn (Socket socket) {
		socketToBuildOn = socket;
	}
		
	public void BuildTower () {

		//Ist nicht mehr noetig
//		if (socketToBuildOn.gotTower) {
//			toastMessageScript.showToastOnUiThread ("Socket blocked!");
//			Debug.Log ("Socket blocked");
//			return;
//		}

		if (PlayerStats.energy < towerToBuild.cost) {
			toastMessageScript.showToastOnUiThread ("Not enough ENERGY!");
			Debug.Log ("Not enough energy");
			return;
		}
		PlayerStats.SubEnergy (towerToBuild.cost);
		GameObject effect = (GameObject) Instantiate (buildEffect, socketToBuildOn.transform.position, Quaternion.identity);
		Destroy (effect, 2.0f);
		GameObject tower = (GameObject) Instantiate (towerToBuild.prefab, socketToBuildOn.GetBuildPosition (), Quaternion.identity);
		socketToBuildOn.tower = tower;
		socketToBuildOn.tower.GetComponent<Tower> ().sellValue = towerToBuild.cost;
		socketToBuildOn.gotTower = true;
		uIManager.DisableUI ();
	}
}