//by Niklas Bachmann
//10.08.2017

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	[Header ("Enemys")]
	public Transform enemySPrefab;
	public Transform enemySBRPrefab;

	[Header ("Configs")]
	public Transform spawnPoint;
	public Text waveCountdownText;
	public int bossIntervall = 10;
	public float timeBetweenWaves = 5.5f;
	public float timeBetweenEnemys = 0.5f;
	private float countdown = 5.5f;
	private int waveIndex = 0;
		
	IEnumerator SpawnWave () {
		waveIndex++;
		if (waveIndex % bossIntervall == 0) {
			for (int i = 0; i < waveIndex / bossIntervall; i++) {
				SpawnEnemy (enemySBRPrefab, waveIndex * 3);
				yield return new WaitForSeconds (timeBetweenEnemys);
			}
		} else {
			for (int i = 0; i < waveIndex; i++) {
				SpawnEnemy (enemySPrefab, waveIndex);
				yield return new WaitForSeconds (timeBetweenEnemys);
			}
		}
	}
		
	void SpawnEnemy (Transform enemy, int amount) {
		Transform spawnedEnemy = Instantiate (enemy, spawnPoint.position, spawnPoint.rotation);
		spawnedEnemy.GetComponent<Enemy> ().startHitPoints += amount - 1;
	}

	void Update () {
		if (countdown <= 0f) {
			StartCoroutine (SpawnWave ());
			countdown = timeBetweenWaves + (waveIndex * timeBetweenEnemys);
		}
		countdown -= Time.deltaTime;
		waveCountdownText.text = "" + Mathf.Round (countdown).ToString () + "s";
	}
}