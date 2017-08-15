//by Niklas Bachmann
//10.08.2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

		buildManager.BuildTower ();
	}


	public void SelectHexaTower () {
		buildManager.SelectTowerToBuild (hexaTower);

		buildManager.BuildTower ();

	}


	public void SelectCircTower () {
		buildManager.SelectTowerToBuild (circTower);

		buildManager.BuildTower ();

	}
}