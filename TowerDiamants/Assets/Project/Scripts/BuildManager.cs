//by Niklas Bachmann
//10.08.2017

using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;

	public GameObject squareTowerPrefab;
	public GameObject hexaTowerPrefab;
	public GameObject circTowerPrefab;

	private TowerBlueprint towerToBuild;
	[HideInInspector]
	public Socket socketToBuildOn;

	private UIManager uIManager;

	void Awake () {
		if (instance != null) {
			return;
		}
		instance = this;
	}

	void Start () {
		uIManager = (UIManager) GameObject.Find("UIManager").GetComponent<UIManager> ();
	}

	public void SelectTowerToBuild (TowerBlueprint tower) {
		towerToBuild = tower;
	}

	public void SelectSocketToBuildOn (Socket socket) {
		socketToBuildOn = socket;
	}
		
	public void BuildTower () {

		if (socketToBuildOn.gotTower) {
			Debug.Log ("Socket blocked");
			return;
		}

		if (PlayerStats.energy < towerToBuild.cost) {
			Debug.Log ("Not enough energy");
			return;
		}
		PlayerStats.SubEnergy (towerToBuild.cost);
		GameObject tower = (GameObject) Instantiate (towerToBuild.prefab, socketToBuildOn.GetBuildPosition (), Quaternion.identity);
		socketToBuildOn.tower = tower;
		socketToBuildOn.gotTower = true;
		uIManager.DisableUI ();
	}
		
	// todo: Towerdelete
	public void DeleteTower () {
	
		// Destroy ();
	
	}
}