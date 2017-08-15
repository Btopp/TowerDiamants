//by Niklas Bachmann
//10.08.2017

using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;

	public GameObject squareTowerPrefab;
	public GameObject hexaTowerPrefab;
	public GameObject circTowerPrefab;

	private TowerBlueprint towerToBuild;

	public bool CanBuild { get { return towerToBuild != null; } }


	void Awake () {
		if(instance != null){
			return;
		}
		instance = this;
	}
		

	public void SelectTowerToBuild (TowerBlueprint tower) {
		towerToBuild = tower;
	}


	public void BuildTowerOn (Socket socket) {
		if (PlayerStats.energy < towerToBuild.cost) {
			Debug.Log ("Not enough energy");
			return;
		}
		PlayerStats.SubEnergy (towerToBuild.cost);
		GameObject tower = (GameObject) Instantiate (towerToBuild.prefab, socket.GetBuildPosition (), Quaternion.identity);
		socket.tower = tower;
	}
}