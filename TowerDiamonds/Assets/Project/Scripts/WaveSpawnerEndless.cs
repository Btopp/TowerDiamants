//by Niklas Bachmann
//10.08.2017

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawnerEndless : MonoBehaviour {

	[Header ("Enemys")]
	public Transform enemySPrefab;
	public Transform enemySBRPrefab;
	public Transform enemySBBPrefab;
	public Transform enemySBGPrefab;

	[Header ("Configs")]
	public Transform spawnPoint;
	public Text waveCountdownText;
	public Text waveIndexText;
	public int bossIntervall = 10;
	public float timeBetweenWaves = 5.5f;
	public float timeBetweenEnemys = 0.5f;

	private float countdown = 5.5f;
	private float bossTimeOffset = 0f;
	private int enemyScaling = 0;
	private int waveIndex = 0;
	private int randomizer;
	private int diaBonusAmount = 1;
	private ToastMessageScript toastMessageScript;

	void Start () {
		toastMessageScript = GameObject.Find ("MASTER").GetComponent<ToastMessageScript> ();
	}

	IEnumerator SpawnWave () {
		waveIndexText.text = (waveIndex + 1).ToString ();
		waveIndex++;
		if (waveIndex % bossIntervall == 0) {
			randomizer = (int) Mathf.Round (Random.Range (0.6f, 3.4f));
			diaBonusAmount += 1;
			toastMessageScript.showToastOnUiThread ("You received " + Mathf.Floor(diaBonusAmount / 2) +" Diamond(s)!");
			bossTimeOffset = (timeBetweenEnemys / 2) * waveIndex;
			for (int i = 0; i < Mathf.Floor(diaBonusAmount / 2); i++) {
				GiveDiamonds ();
			}
			for (int i = 0; i < waveIndex / bossIntervall; i++) {
				if (randomizer == 1) {
//					SpawnEnemy (enemySBBPrefab, (waveIndex - 1) * 3.0f);
					SpawnEnemy (enemySBBPrefab, (waveIndex / bossIntervall) * enemyScaling);
				}
				if (randomizer == 2) {
//					SpawnEnemy (enemySBGPrefab, (waveIndex - 1) * 3.0f);
					SpawnEnemy (enemySBGPrefab, (waveIndex / bossIntervall) * enemyScaling);
				}
				if (randomizer == 3) {
//					SpawnEnemy (enemySBRPrefab, (waveIndex - 1) * 3.0f);
					SpawnEnemy (enemySBRPrefab, (waveIndex / bossIntervall) * enemyScaling);
				}
				enemyScaling += 1;
				yield return new WaitForSeconds (timeBetweenEnemys);
			}
		} else {
			bossTimeOffset = 0f;
			for (int i = 0; i < waveIndex; i++) {
//				SpawnEnemy (enemySPrefab, waveIndex * 1.5f);
				SpawnEnemy (enemySPrefab, enemyScaling);
				yield return new WaitForSeconds (timeBetweenEnemys);
			}
		}
	}
		
	void SpawnEnemy (Transform enemy, float amount) {
		Transform spawnedEnemy = Instantiate (enemy, spawnPoint.position, spawnPoint.rotation);
		spawnedEnemy.GetComponent<Enemy> ().startHitPoints += amount;
	}
		
	void GiveDiamonds () {
		PlayerStats.AddDiamondsToUse (randomizer, 1);
	}

	void Update () {
		if (countdown <= 0f) {
			StartCoroutine (SpawnWave ());
			countdown = timeBetweenWaves + (waveIndex * timeBetweenEnemys - bossTimeOffset);
		}
		countdown -= Time.deltaTime;
		waveCountdownText.text = "" + Mathf.Round (countdown).ToString () + "s";
	}
}