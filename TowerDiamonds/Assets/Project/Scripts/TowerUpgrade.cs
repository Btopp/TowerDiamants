//by Niklas Bachmann
//16.08.2017

using UnityEngine;

[RequireComponent(typeof(Tower))]
public class TowerUpgrade : MonoBehaviour {

	[HideInInspector]
	public Diamond slotOneDia;
	[HideInInspector]
	public Diamond slotTwoDia;
	[HideInInspector]
	public Diamond slotThreeDia;
	[HideInInspector]
	public Sprite slotOneSprite;
	[HideInInspector]
	public Sprite slotTwoSprite;
	[HideInInspector]
	public Sprite slotThreeSprite;

	public void SetSlotOneSprite (Sprite sprite) {
		slotOneSprite = sprite;	
	}

	public void SetSlotTwoSprite (Sprite sprite) {
		slotOneSprite = sprite;	
	}

	public void SetSlotThreeSprite (Sprite sprite) {
		slotOneSprite = sprite;	
	}

	public void SaveSlots (Sprite slot1Sprite, Sprite slot2Sprite, Sprite slot3Sprite) {
		slotOneSprite = slot1Sprite;
		slotTwoSprite = slot2Sprite;
		slotThreeSprite = slot3Sprite;
	}
}