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
		
	void OnMouseExit () {
		if(EventSystem.current.IsPointerOverGameObject ()){
			return;
		}
		SetIdolColor ();
	}

	public void SetIdolColor () {
		rend.material.color = idolColor;
	}

	public void SetHoverColor () {
		rend.material.color = hoverColor;
	}

	void OnMouseDown () {
		if (uIManager.selectedSocket != null) {
			uIManager.selectedSocket.SetIdolColor ();
			if (uIManager.selectedSocket.tower != null) {
				uIManager.selectedSocket.tower.GetComponent<Tower> ().SetRangeIndicatorOff ();
			}
		}
		rend.material.color = hoverColor;
		buildManager.SelectSocketToBuildOn (this);
		uIManager.SetSelectedSocket (this);
		if (tower != null) {
			upgradeManager.SetSelectedTower (tower);
			uIManager.EnableTowerDetails ();
			upgradeManager.SetSlotSprites ();
			tower.GetComponent<Tower> ().SetRangeIndicatorOn ();
			SetHoverColor ();
			return;
		}
		uIManager.EnableTowerShop ();
	}
}