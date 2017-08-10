using UnityEngine;
using UnityEngine.EventSystems;

//by Niklas Bachmann
//10.08.2017

public class Socket : MonoBehaviour {

	public Color hoverColor;
	private Color idolColor;

	public Vector3 positionOffset;

	private Renderer rend;

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
		if(!buildManager.CanBuild){
			return;
		}
		rend.material.color = hoverColor;
	}


	void OnMouseExit () {
		rend.material.color = idolColor;
	}


	void OnMouseDown () {
		if(!buildManager.CanBuild){
			return;
		}
		if(tower != null){
			Debug.Log ("Socket blocked");
			return;
		}
		buildManager.BuildTowerOn (this);
	}
}