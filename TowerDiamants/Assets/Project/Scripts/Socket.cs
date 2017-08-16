//by Niklas Bachmann
//10.08.2017

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Socket : MonoBehaviour {

	public Color hoverColor;
	private Color idolColor;

	public Vector3 positionOffset;

	private Renderer rend;

	[HideInInspector]
	public bool gotTower = false;

	BuildManager buildManager;

	[HideInInspector]
	public GameObject tower;

	private UIManager uIManager;

	public Vector3 GetBuildPosition () {
		return transform.position + positionOffset;
	}
		
	void Start(){
		uIManager = (UIManager) GameObject.Find("UIManager").GetComponent<UIManager> ();
		rend = GetComponent<Renderer> ();
		buildManager = BuildManager.instance;
		if (rend.material.color != null) {
			idolColor = rend.material.color;
		}
	}
		
	//FUER SP ENABLED
//	void OnMouseEnter () {
////		if(!buildManager.CanBuild){
////			return;
////		}
//		if(EventSystem.current.IsPointerOverGameObject ()){
//			return;
//		}
//
//		rend.material.color = hoverColor;
//	}
		
	void OnMouseExit () {
		rend.material.color = idolColor;

		// -> MUSS FUER SMARTPONE AKTIVE SEIN
//		uIManager.DisableUI ();
	}

	void OnMouseDown () {
		if(EventSystem.current.IsPointerOverGameObject ()){
			return;
		}
		rend.material.color = hoverColor;
		buildManager.SelectSocketToBuildOn (this);
//		if(!buildManager.CanBuild){
//			return;
//		}
		if(tower != null){
			uIManager.EnableTowerDetails ();
			return;
		}
		uIManager.EnableTowerShop ();
	}
}