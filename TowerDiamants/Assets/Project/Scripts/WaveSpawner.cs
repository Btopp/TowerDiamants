using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//by Niklas Bachmann
//10.08.2017

public class WaveSpawner : MonoBehaviour {

	public Transform enemyPrefab;
	public Transform spawnPoint;
	public Text waveCountdownText;

	public float timeBetweenWaves = 5.5f;
	public float timeBetweenEnemys = 0.6f;

	private float countdown = 3.5f;

	private int waveIndex = 0;


	void Update () {
		if (countdown <= 0f) {
			StartCoroutine (SpawnWave ());
			countdown = timeBetweenWaves + (waveIndex * timeBetweenEnemys);
		}
		countdown -= Time.deltaTime;
		waveCountdownText.text = "" + Mathf.Round (countdown).ToString () + "s";
	}


	IEnumerator SpawnWave () {
		waveIndex++;
		for (int i = 0; i < waveIndex; i++) {
			SpawnEnemy ();
			yield return new WaitForSeconds (timeBetweenEnemys);
		}
	}


	void SpawnEnemy () {
		Instantiate (enemyPrefab, spawnPoint.position, spawnPoint.rotation);
	}
}