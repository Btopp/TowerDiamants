//by Niklas Bachmann
//10.08.2017

using UnityEngine;

public class Projectile : MonoBehaviour {

	private Transform target;
	public float speed = 20f;
	public float explosionRadius = 0f;
	[HideInInspector]
	public float damage = 1f;
	public GameObject impactEffekt;
	[HideInInspector]
	public float slowPercent = 0f;

	public void Seek (Transform _target) {
		target = _target;
	}		

	void HitTarget () {
		GameObject effectIns = Instantiate (impactEffekt, transform.position, transform.rotation);
		Destroy (effectIns, 2.0f);
		if (explosionRadius > 0f) {		
			Explode ();		
		} else {
			Damage (target);
		}
		Destroy (gameObject);
	}

	void Explode () {	
		Collider[] colliders = Physics.OverlapSphere (transform.position, explosionRadius);
		foreach (Collider collider in colliders) {
			if (collider.tag == "Enemy") {
				Damage (collider.transform);
			}			
		}	
	}

	void Damage (Transform enemy) {
		if (slowPercent > 0) {
			if (target == enemy) {
				enemy.GetComponent<Enemy>().Slow (slowPercent);
			} else {
				enemy.GetComponent<Enemy>().Slow (slowPercent / 2);
			}

		}
		enemy.GetComponent<Enemy> ().SubHitPoints (damage);
	}

	void OnDrawGizmosSelected () {	
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, explosionRadius);	
	}

	void Update () {
		if(target == null){
			Destroy (gameObject);
			return;
		}
		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;
		if (dir.magnitude <= distanceThisFrame) {
			HitTarget ();
			return;
		}
		transform.Translate (dir.normalized * distanceThisFrame, Space.World);
		transform.LookAt (target);
	}
}