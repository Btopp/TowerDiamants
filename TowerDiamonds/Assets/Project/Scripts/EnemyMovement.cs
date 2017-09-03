//by Niklas Bachmann
//22.08.2017

using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

	private Transform target;
	private int wavepointIndex = 0;
	private float slowCountdown = 0f;
	public float slowTime = 2f;
	private Enemy enemy;
	private AudioManager audioManager;

	void Start () {
		audioManager = GameObject.Find ("MASTER").GetComponent<AudioManager> ();
		enemy = GetComponent<Enemy> ();
		target = Waypoints.targets [0];
	}

	void GetNextWaypoint () {
		if (wavepointIndex >= Waypoints.targets.Length - 1) {
			ReachLastWaypoint ();
			return;
		}
		wavepointIndex++;
		target = Waypoints.targets [wavepointIndex];
	}

	void ReachLastWaypoint () {
		audioManager.PlayFailSound ();
		PlayerStats.SubHearts (1);
		Destroy (gameObject);
	}

	void Update () {
		Vector3 dir = target.position - transform.position;
		transform.Translate (dir.normalized * enemy.speed * Time.deltaTime);
		if (Vector3.Distance (transform.position, target.position) <= 0.3) {
			GetNextWaypoint ();
		}
		if (slowCountdown <= 0f) {
			enemy.speed = enemy.startSpeed;
			slowCountdown = slowTime;
		}
		slowCountdown -= Time.deltaTime;

	}
}