//by Niklas Bachmann
//10.08.2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

	public static int energy;
	public int startEngergy = 100;

	public static int hearts;
	public int startHearts = 5;

	public Text energyText;
	public Text heartsText;
	public static Text _energyText;
	public static Text _heartsText;

	public GameObject energyBonusText;
	public static GameObject _energyBonusText;

	public int blueDiamonds = 0;
	public int greenDiamonds = 0;
	public int redDiamonds = 0;
	public static int blueDiasToUse;
	public static int greenDiasToUse;
	public static int redDiasToUse;
	public Text blueDiaText;
	public Text greenDiaText;
	public Text RedDiaText;
	public static Text _blueDiaText;
	public static Text _greenDiaText;
	public static Text _redDiaText;
	public static bool sound = true;
	public static bool music = true;

	//muss ausgelagert werden
	public static float timerForBonusText = 0.0f;

	void Start () {
		_energyText = energyText;
		_heartsText = heartsText;
		_energyBonusText = energyBonusText;
		energy = startEngergy;
		hearts = startHearts;
		blueDiasToUse = blueDiamonds;
		greenDiasToUse = greenDiamonds;
		redDiasToUse = redDiamonds;
		_blueDiaText = blueDiaText;
		_greenDiaText = greenDiaText;
		_redDiaText = RedDiaText;
		UpdateEnergyText ();
		UpdateHeartsText ();
		UpdateDiamondText ();
	}
		
	public static void UpdateEnergyText () {
		_energyText.text = energy.ToString ();
	}
		
	public static void UpdateHeartsText () {
		_heartsText.text = hearts.ToString ();
	}

	public static void UpdateDiamondText () {
		_blueDiaText.text = "x" + blueDiasToUse;
		_greenDiaText.text = "x" + greenDiasToUse;
		_redDiaText.text = "x" + redDiasToUse;
	}
		
	public static void SubEnergy (int amount) {
		energy -= amount;
		UpdateEnergyText ();
	}
		
	public static void SubHearts (int amount) {
		hearts -= amount;
		UpdateHeartsText ();
	}
		
	public static void AddEnergy (int amount) {
		energy += amount;
		UpdateEnergyText ();
	}

	public static void AddEnergyBonus () {
		_energyBonusText.SetActive (true);
		timerForBonusText = 3.5f;
		int energyBonus = (int) Mathf.Round(energy * 0.1f);
		energy += energyBonus;
		UpdateEnergyText ();
	}
		
	public static void AddHearts (int amount) {
		hearts += amount;
		UpdateHeartsText ();
	}

	public static void SubDiamondsToUse (int colorID, int amount) {
		// ColorID: 1-Blue, 2-Green, 3-Red
		if (colorID == 1) {
			blueDiasToUse -= amount;
		}
		if (colorID == 2) {
			greenDiasToUse -= amount;
		}
		if (colorID == 3) {
			redDiasToUse -= amount;
		}
		UpdateDiamondText ();
	}

	public static void AddDiamondsToUse (int colorID, int amount) {
		// ColorID: 1-Blue, 2-Green, 3-Red
		if (colorID == 1) {
			blueDiasToUse += amount;
		}
		if (colorID == 2) {
			greenDiasToUse += amount;
		}
		if (colorID == 3) {
			redDiasToUse += amount;
		}
		UpdateDiamondText ();
	}

	//muss ausgelagert werden
	void Update () {
		//timer for energybonustext
		if (timerForBonusText <= 0) {
			if (!(_energyBonusText.activeSelf)){
				return;
			}
			_energyBonusText.SetActive (false);
		} else {
			timerForBonusText -= Time.deltaTime;
		}	
	}
}