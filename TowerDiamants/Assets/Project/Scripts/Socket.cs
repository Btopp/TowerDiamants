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
	private UpgradeManager upgradeManager;

	public Vector3 GetBuildPosition () {
		return transform.position + positionOffset;
	}
		
	void Start(){
		uIManager = (UIManager) GameObject.Find("UIManager").GetComponent<UIManager> ();
		upgradeManager = (UpgradeManager) GameObject.Find("UpgradeManager").GetComponent<UpgradeManager> ();
		rend = GetComponent<Renderer> ();
		buildManager = BuildManager.instance;
		if (rend.material.color != null) {
			idolColor = rend.material.color;
		}
	}
		
	//FUER SP DISABLED
//	void OnMouseEnter () {
//		if(EventSystem.current.IsPointerOverGameObject ()){
//			return;
//		}
//
//		rend.material.color = hoverColor;
//	}
		
	void OnMouseExit () {
		if (EventSystem.current.IsPointerOverGameObject ()) {
			return;
		}
		rend.material.color = idolColor;
	}

	void OnMouseDown () {
		if (EventSystem.current.IsPointerOverGameObject ()) {
			return;
		}
		rend.material.color = hoverColor;
		buildManager.SelectSocketToBuildOn (this);
		if (tower != null) {
			upgradeManager.SetSelectedTower (tower);
			uIManager.EnableTowerDetails ();
			upgradeManager.SetSlotSprites ();
			return;
		}
		uIManager.EnableTowerShop ();
	}
}