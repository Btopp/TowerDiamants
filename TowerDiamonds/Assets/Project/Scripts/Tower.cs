//by Niklas Bachmann
//10.08.2017

using UnityEngine;

public class Tower : MonoBehaviour {

	[Header ("General")]
	public float startRange = 8f;
	//+100 for % correction
	public float slowPercent = 100;
	public GameObject rangeIndicator;
	public string enemyTag = "Enemy";
	public Transform partToRotate;
	public float turnSpeed = 10f;
	public Transform firePoint;
	public AudioClip shotSound;
	private AudioManager audioManager;
	[HideInInspector]
	public float range;
	[HideInInspector]
	public int sellValue;
	private Transform target;
	private Enemy targetEnemy;
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

	void Start () {
		damagePerSec = startDamagePerSec;
		projectileDamage = startProjectileDamage;
		range = startRange;
		audioManager = GameObject.Find ("MASTER").GetComponent<AudioManager> ();
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
	}

	public void EnableRangeIndicator () {
		rangeIndicator.SetActive (true);
	}

	public void DisableRangeIndicator () {
		rangeIndicator.SetActive (false);
	}

	void Shoot () {
		audioManager.PlayShotSound (shotSound);
		GameObject projectileGO = Instantiate (projectilePrefab, firePoint.position, firePoint.rotation);
		Projectile projectile = projectileGO.GetComponent<Projectile> ();
		if (projectile != null) {
			projectile.damage = projectileDamage;
			projectile.slowPercent = slowPercent - 100;
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

		if (slowPercent > 100f) {
		
			targetEnemy.Slow (slowPercent - 100f);
		
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

	void OnDrawGizmosSelected () {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
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

	public void SetSlow () {
		if (slowPercent == 100f) {
			slowPercent += 25f;
		} else {
			slowPercent *= 1.25f;
		}
	}

	public void SetRange () {
		range *= 1.15f;
		rangeIndicator.transform.localScale *= 1.15f;
	}

	public void SetDamage () {
		projectileDamage *= 1.5f;
		damagePerSec *= 1.5f;
	}

	public void SetRangeIndicatorOn () {
		rangeIndicator.SetActive (true);
	}

	public void SetRangeIndicatorOff () {
		rangeIndicator.SetActive (false);
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