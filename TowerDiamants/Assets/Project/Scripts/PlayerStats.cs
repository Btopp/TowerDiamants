using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//by Niklas Bachmann
//10.08.2017

public class PlayerStats : MonoBehaviour {

	public static int energy;
	public int startEngergy = 100;

	public static int hearts;
	public int startHearts = 5;


	public Text energyText;
	public Text heartsText;
	public static Text _energyText;
	public static Text _heartsText;


	void Start () {
		_energyText = energyText;
		_heartsText = heartsText;
		energy = startEngergy;
		hearts = startHearts;
		UpdateEnergyText ();
		UpdateHeartsText ();
	}


	public static void UpdateEnergyText () {
		_energyText.text = energy.ToString ();
	}


	public static void UpdateHeartsText () {
		_heartsText.text = hearts.ToString ();
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


	public static void AddHearts (int amount) {
		hearts += amount;
		UpdateHeartsText ();
	}
}
