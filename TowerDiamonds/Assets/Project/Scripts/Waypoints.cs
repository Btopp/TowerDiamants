//by Niklas Bachmann
//10.08.2017

using UnityEngine;

public class Waypoints : MonoBehaviour {

	public static Transform[] targets;

	void Awake () {
		targets = new Transform[transform.childCount];
		for (int i = 0; i < targets.Length; i++) {
			targets[i] = transform.GetChild (i);
		}
	}
}