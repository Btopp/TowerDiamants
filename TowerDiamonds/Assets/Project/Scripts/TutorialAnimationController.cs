//by Niklas Bachmann
//30.08.2017

using UnityEngine;

public class TutorialAnimationController : MonoBehaviour {

	public Animator animator;

	void OnMouseDown () {
		animator = gameObject.GetComponent<Animator> ();
		Destroy (animator);
	}
}