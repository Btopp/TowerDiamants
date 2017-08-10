using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//by Niklas Bachmann
//10.08.2017

public class Tower : MonoBehaviour {

	public string enemyTag = "Enemy";

	private Transform target;

	public float range = 8f;
	public float fireRate = 1f;
	private float fireCountdown = 0f;

	public Transform partToRotate;
	public float turnSpeed = 10f;

	public GameObject projectilePrefab;
	public Transform firePoint;


	void Start () {
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
	}


	void UpdateTarget(){

		GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemyTag);

		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;

		foreach (GameObject enemy in enemies) {

			float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance) {

				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;

			}
		}

		if (nearestEnemy != null && shortestDistance <= range) {

			target = nearestEnemy.transform;

		} else {

			target = null;

		}

	}


	void Shoot(){

		GameObject projectileGO = Instantiate (projectilePrefab, firePoint.position, firePoint.rotation);
		Projectile projectile = projectileGO.GetComponent<Projectile> ();

		if (projectile != null) {

			projectile.Seek (target);

		}
	}
		

	void Update () {

		if (target == null) {
			return;
		}

		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation (dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);

		if (fireCountdown <= 0f) {

			Shoot ();
			fireCountdown = 1f / fireRate;

		}

		fireCountdown -= Time.deltaTime;
	}


	void OnDrawGizmosSelected(){

		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}

}