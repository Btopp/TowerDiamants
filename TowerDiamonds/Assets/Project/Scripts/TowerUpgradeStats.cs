//by Niklas Bachmann
//16.08.2017

using UnityEngine;

public class TowerUpgradeStats : MonoBehaviour {

	[HideInInspector]
	public Sprite slotOneSprite;
	[HideInInspector]
	public Sprite slotTwoSprite;
	[HideInInspector]
	public Sprite slotThreeSprite;

	private UIManager uIManager;
	private UpgradeManager upgradeManager;

	void Start(){
		uIManager = (UIManager) GameObject.Find("UIManager").GetComponent<UIManager> ();
		upgradeManager = (UpgradeManager) GameObject.Find("UpgradeManager").GetComponent<UpgradeManager> ();
	}

	public void SetSlotOneSprite (Sprite sprite) {
		slotOneSprite = sprite;	
	}

	public void SetSlotTwoSprite (Sprite sprite) {
		slotOneSprite = sprite;	
	}

	public void SetSlotThreeSprite (Sprite sprite) {
		slotOneSprite = sprite;	
	}

	public void SaveSlotSprites (Sprite slot1Sprite, Sprite slot2Sprite, Sprite slot3Sprite) {
		slotOneSprite = slot1Sprite;
		slotTwoSprite = slot2Sprite;
		slotThreeSprite = slot3Sprite;
	}
}
