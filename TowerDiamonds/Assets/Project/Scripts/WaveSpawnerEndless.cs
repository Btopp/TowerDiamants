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

	//neu
	private bool bossWas = false;

	void Start () {
		toastMessageScript = GameObject.Find ("MASTER").GetComponent<ToastMessageScript> ();
	}

	IEnumerator SpawnWave () {
		waveIndexText.text = (waveIndex + 1).ToString ();
		waveIndex++;
		//Money Bonus 10%
		if (waveIndex > 1) {
			PlayerStats.AddEnergyBonus ();
		}
		if (waveIndex % bossIntervall == 0) {
			bossWas = true;
			randomizer = (int) Mathf.Round (Random.Range (0.51f, 3.49f));
			diaBonusAmount += 1;
			toastMessageScript.showToastOnUiThread ("You received " + Mathf.Floor(diaBonusAmount / 2) +" Diamond(s)!");
			bossTimeOffset = (timeBetweenEnemys / 2) * waveIndex;
			for (int i = 0; i < Mathf.Floor(diaBonusAmount / 2); i++) {
				GiveDiamonds ();
			}
			for (int i = 0; i < waveIndex / bossIntervall; i++) {
				if (randomizer == 1) {
					SpawnEnemy (enemySBBPrefab, (waveIndex / bossIntervall) * enemyScaling * 0.7f);
				}
				if (randomizer == 2) {
					SpawnEnemy (enemySBGPrefab, (waveIndex / bossIntervall) * enemyScaling * 0.8f);
				}
				if (randomizer == 3) {
					SpawnEnemy (enemySBRPrefab, (waveIndex / bossIntervall) * enemyScaling * 0.9f);
				}
				enemyScaling += 1;
				yield return new WaitForSeconds (timeBetweenEnemys);
			}
		} else {
			if (bossWas) {
				//do things after boss
				bossWas = false;
			}
			bossTimeOffset = 0f;
			for (int i = 0; i < waveIndex; i++) {
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