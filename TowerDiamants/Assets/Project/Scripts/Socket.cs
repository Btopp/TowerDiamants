//by Niklas Bachmann
//10.08.2017

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Socket : MonoBehaviour {

	public Color hoverColor;
	private Color idolColor;

	public Transform towerShop;
	public Transform towerDetails;

	public Vector3 positionOffset;

	private Renderer rend;

	[HideInInspector]
	public bool gotTower = false;

	BuildManager buildManager;

	[HideInInspector]
	public GameObject tower;

	public Vector3 GetBuildPosition () {
		return transform.position + positionOffset;
	}


	void Start(){
		rend = GetComponent<Renderer> ();
		buildManager = BuildManager.instance;
		if (rend.material.color != null) {
			idolColor = rend.material.color;
		}
	}
		

	void OnMouseEnter () {
//		if(!buildManager.CanBuild){
//			return;
//		}
		rend.material.color = hoverColor;
	}


	void OnMouseExit () {
		rend.material.color = idolColor;

		//AUSLAGERN IN UI-Script
		//Schlecht fuers testen auf pc geht nur auf smartphone
		towerDetails.gameObject.SetActive(false);
		towerShop.gameObject.SetActive(false);
	}


	void OnMouseDown () {

		buildManager.SelectSocketToBuildOn (this);

//		if(!buildManager.CanBuild){
//			return;
//		}
		if(tower != null){

			//AUSLAGERN IN UI-Script
			towerShop.gameObject.SetActive(false);
			towerDetails.gameObject.SetActive(true);
			return;
		}

		//muss mit dem shop verknüpft sein
		//AUSLAGERN IN UI-Script
		towerDetails.gameObject.SetActive(false);
		towerShop.gameObject.SetActive(true);

	}
}