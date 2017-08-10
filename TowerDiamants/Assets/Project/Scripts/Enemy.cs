using UnityEngine;
using UnityEngine.UI;

//by Niklas Bachmann
//10.08.2017

public class Enemy : MonoBehaviour {

	//Enemy Stats
	[HideInInspector]
	public int hitPoints;
	public int startHitPoints = 1;
	public int speed = 5;

	private Transform target;
	private int wavepointIndex = 0;


	void Start () {
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


	public void SubHitPoints (int amount) {
		hitPoints -= amount;
		if (hitPoints <= 0) {
			Die ();
		}
	}


	void Die () {
		PlayerStats.AddEnergy (10);
		Destroy (gameObject);
	}


	void ReachLastWaypoint () {
		PlayerStats.SubHearts (1);
		Destroy (gameObject);
	}
}