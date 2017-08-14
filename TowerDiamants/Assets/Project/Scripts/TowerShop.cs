using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//by Niklas Bachmann
//10.08.2017

public class TowerShop : MonoBehaviour {

	BuildManager buildManager;

	public TowerBlueprint squareTower;
	public TowerBlueprint hexaTower;
	public TowerBlueprint circTower;

	void Start () {
		squareTower.costText.text = squareTower.cost.ToString ();
		hexaTower.costText.text = hexaTower.cost.ToString ();
		circTower.costText.text = circTower.cost.ToString ();
		buildManager = BuildManager.instance;
	}


	public void SelectSquareTower () {
		buildManager.SelectTowerToBuild(squareTower);
	}


	public void SelectHexaTower () {
		buildManager.SelectTowerToBuild (hexaTower);
	}


	public void SelectCircTower () {
		buildManager.SelectTowerToBuild (circTower);
	}
}