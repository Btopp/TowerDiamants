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

	private Transform target;
	private int wavepointIndex = 0;


	void Start () {
		hitPoints = startHitPoints;
		target = Waypoints.targets [0];
		hitPoints = startHitPoints;
	}
		

	void Update () {
		Vector3 dir = target.position - transform.position;
		transform.Translate (dir.normalized * speed * Time.deltaTime);
		if (Vector3.Distance (transform.position, target.position) <= 0.3) {
			GetNextWaypoint ();
		}
	}


	void GetNextWaypoint () {
		if (wavepointIndex >= Waypoints.targets.Length - 1) {
			ReachLastWaypoint ();
			return;
		}
		wavepointIndex++;
		target = Waypoints.targets [wavepointIndex];
	}


	public void SubHitPoints (float amount) {
		hitPoints -= amount;
		if (hitPoints <= 0) {
			Die ();
		}
	}


	void Die () {
		PlayerStats.AddEnergy (energyBonus);
		Destroy (gameObject);
	}


	void ReachLastWaypoint () {
		PlayerStats.SubHearts (1);
		Destroy (gameObject);
	}
}