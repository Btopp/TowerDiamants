//by Niklas Bachmann
//10.08.2017

using UnityEngine;

public class Tower : MonoBehaviour {

	[Header ("General")]
	public float startRange = 8f;
	[HideInInspector]
	public float range;
	public int slowPercent = 0;
	public GameObject rangeIndicator;

	[Header ("Use Projectiles")]
	public GameObject projectilePrefab;
	public float fireRate = 1f;
	private float fireCountdown = 0f;
	public float startProjectileDamage = 1f;
	[HideInInspector]
	public float projectileDamage = 0f;

	[Header ("Use Laser")]
	public bool useLaser = false;
	public LineRenderer lineRenderer;
	public ParticleSystem impactEffect; 
	public float startDamagePerSec = 0f;
	[HideInInspector]
	public float damagePerSec = 0f;

	public string enemyTag = "Enemy";
	private Transform target;
	private Enemy targetEnemy;

	public Transform partToRotate;
	public float turnSpeed = 10f;

	public Transform firePoint;

	[HideInInspector]
	public int sellValue;

	void Start () {
		damagePerSec = startDamagePerSec;
		projectileDamage = startProjectileDamage;
		range = startRange;
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
	}

	public void EnableRangeIndicator () {
		rangeIndicator.SetActive (true);
	}

	public void DisableRangeIndicator () {
		rangeIndicator.SetActive (false);
	}

	void Shoot(){
		GameObject projectileGO = Instantiate (projectilePrefab, firePoint.position, firePoint.rotation);
		Projectile projectile = projectileGO.GetComponent<Projectile> ();
		if (projectile != null) {
			projectile.damage = projectileDamage;
			projectile.slowPercent = slowPercent;
			projectile.Seek (target);
		}
	}

	void LockOnTarget () {	
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation (dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);
	}

	void Laser () {
		targetEnemy.SubHitPoints (damagePerSec * Time.deltaTime);

		if (slowPercent > 0) {
		
			targetEnemy.Slow (slowPercent);
		
		}

		if (!lineRenderer.enabled) {			
			lineRenderer.enabled = true;
			impactEffect.Play ();		
		}	
		lineRenderer.SetPosition (0, firePoint.position);
		lineRenderer.SetPosition (1, target.position);

		Vector3 dir = firePoint.position - target.position;

		impactEffect.transform.position = target.position + dir.normalized * 0.25f;

		impactEffect.transform.rotation = Quaternion.LookRotation (dir);

	}

	//todo: ingame Rangeindicator

	void OnDrawGizmosSelected () {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, startRange);
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
			targetEnemy = nearestEnemy.GetComponent<Enemy> ();
		} else {
			target = null;
		}
	}

	void Update () {
		if (target == null) {
			if (useLaser) {
				if (lineRenderer.enabled) {
					lineRenderer.enabled = false;
					impactEffect.Stop ();
				}
			}
			return;
		}
		LockOnTarget ();
		if (useLaser) {
			Laser ();
		} else {
			if (fireCountdown <= 0f) {
				Shoot ();
				fireCountdown = 1f / fireRate;
			}
			fireCountdown -= Time.deltaTime;
		}
	}
}