using UnityEngine;

//by Niklas Bachmann
//10.08.2017

public class Projectile : MonoBehaviour {

	private Transform target;

	public float speed = 20f;

	public int damage = 1;

	public GameObject impactEffekt;


	public void Seek (Transform _target) {

		target = _target;

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

	}


	void HitTarget (){

		GameObject effectIns = Instantiate (impactEffekt, transform.position, transform.rotation);

		Destroy (effectIns, 2f);

		target.GetComponent<Enemy> ().SubHitPoints (damage);

		Destroy (gameObject);

	}

}