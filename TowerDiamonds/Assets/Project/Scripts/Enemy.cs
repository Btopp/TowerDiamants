//by Niklas Bachmann
//10.08.2017

using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	//Enemy Stats
	[HideInInspector]
	public float hitPoints;
	public float startHitPoints = 1.0f;
	[HideInInspector]
	public float speed;
	public float startSpeed = 5.0f;
	public int energyBonus = 15;

	public GameObject deathEffect;

	void Start () {
		speed = startSpeed;
		hitPoints = startHitPoints;
		hitPoints = startHitPoints;
	}
		
	public void SubHitPoints (float amount) {
		hitPoints -= amount;
		if (hitPoints <= 0) {
			Die ();
		}
	}

	void Die () {
		GameObject effect = (GameObject) Instantiate (deathEffect, transform.position, Quaternion.identity);
		Destroy (effect, 2.0f);
		PlayerStats.AddEnergy (energyBonus);
		Destroy (gameObject);
	}

	public void Slow (float percent){
		speed = startSpeed * (1 - (percent / 100));
	}
}