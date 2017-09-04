//by Niklas Bachmann
//26.08.2017

using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour {

	AudioSource audioSource;
	public AudioClip deathSound;
	public AudioClip spawnSound;
	public AudioClip failSound;

	void Start () {
		audioSource = gameObject.GetComponent<AudioSource> ();
		if (PlayerStats.sound == false) {
			audioSource.enabled = false;
		}
	}

	public void PlayDeathSound () {
		audioSource.PlayOneShot (deathSound, Random.Range(0.6f, 0.62f));
	}

	public void PlayShotSound (AudioClip sound) {
		audioSource.PlayOneShot (sound, Random.Range(0.98f, 1.0f));
	}

	public void PlaySpawnSound () {
	}

	public void PlayFailSound () {
		audioSource.PlayOneShot (failSound, Random.Range (0.33f, 0.35f));
	}
}