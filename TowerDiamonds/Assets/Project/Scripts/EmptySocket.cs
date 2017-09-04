//by Niklas Bachmann
//26.08.2017

using UnityEngine;
using UnityEngine.EventSystems;

public class EmptySocket : MonoBehaviour {

	private UIManager uIManager;

	void Start(){
		uIManager = (UIManager) GameObject.Find("UIManager").GetComponent<UIManager> ();
	}

	void OnMouseDown () {
		if(EventSystem.current.IsPointerOverGameObject ()){
			return;
		}
		uIManager.DisableUI ();
		if (uIManager.selectedSocket != null) {
			uIManager.selectedSocket.SetIdolColor ();
			if (uIManager.selectedSocket.tower != null) {
				uIManager.selectedSocket.tower.GetComponent<Tower> ().SetRangeIndicatorOff ();
			}
		}
	}
}