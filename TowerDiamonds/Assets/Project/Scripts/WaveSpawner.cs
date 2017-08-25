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
	public Text waveIndexText;
	public int bossIntervall = 10;
	public float timeBetweenWaves = 5.5f;
	public float timeBetweenEnemys = 0.5f;
	private float countdown = 5.5f;
	private int waveIndex = 0;

	//Vorerst: todo: auslagern
	private ToastMessageScript toastMessageScript;

	void Start () {
		toastMessageScript = GameObject.Find ("MASTER").GetComponent<ToastMessageScript> ();
	}

	IEnumerator SpawnWave () {
		waveIndexText.text = (waveIndex + 1).ToString ();
		waveIndex++;
		if (waveIndex % bossIntervall == 0) {
			//EXPERIMENTEL
			GiveDiamonds ();
			for (int i = 0; i < waveIndex / bossIntervall; i++) {
				SpawnEnemy (enemySBRPrefab, waveIndex * 2.0f);
				yield return new WaitForSeconds (timeBetweenEnemys);
			}
		} else {
			for (int i = 0; i < waveIndex; i++) {
				SpawnEnemy (enemySPrefab, waveIndex * 1.0f);
				yield return new WaitForSeconds (timeBetweenEnemys);
			}
		}
	}
		
	void SpawnEnemy (Transform enemy, float amount) {
		Transform spawnedEnemy = Instantiate (enemy, spawnPoint.position, spawnPoint.rotation);
		spawnedEnemy.GetComponent<Enemy> ().startHitPoints += amount - 1;
	}

	//ESPERIMENTEL
	void GiveDiamonds () {
		int random = (int) Mathf.Round (Random.Range (0.6f, 3.4f));
		PlayerStats.AddDiamondsToUse (random, 1);
		toastMessageScript.showToastOnUiThread ("You receive a Diamond!");
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