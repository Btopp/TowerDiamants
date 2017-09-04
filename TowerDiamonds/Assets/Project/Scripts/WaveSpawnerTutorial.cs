//by Niklas Bachmann
//26.08.2017

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawnerTutorial : MonoBehaviour {

	[Header ("Enemys")]
	public Transform enemySPrefab;
	public Transform enemySBBPrefab;
	[Header ("Configs")]
	public Transform spawnPoint;
	public Text waveCountdownText;
	public Text waveIndexText;
	public float timeBetweenWaves = 5.5f;
	public float timeBetweenEnemys = 0.5f;
	private float countdown = 10.5f;
	private int waveIndex = 0;
	private UIManager uIManager;
	private ToastMessageScript toastMessageScript;

	void Start () {
		uIManager = (UIManager) GameObject.Find("UIManager").GetComponent<UIManager> ();
		toastMessageScript = GameObject.Find ("MASTER").GetComponent<ToastMessageScript> ();
		toastMessageScript.showToastOnUiThread ("Press flashing platform!");
	}

	IEnumerator SpawnWave () {
		waveIndexText.text = (waveIndex + 1).ToString ();
		waveIndex++;
		if (waveIndex == 3) {
			uIManager.EnableComplete ();
			Time.timeScale = 0f;
			yield return new WaitForSeconds(5f);
		}
		if (waveIndex == 2) {
			SpawnEnemy (enemySBBPrefab, (-0.5f));
			yield return new WaitForSeconds (timeBetweenEnemys);
		} else {
			for (int i = 0; i < 3 * waveIndex; i++) {
				SpawnEnemy (enemySPrefab, waveIndex);
				yield return new WaitForSeconds (timeBetweenEnemys);
			}
		}
		yield return new WaitForSeconds (0.0f);
	}

	void SpawnEnemy (Transform enemy, float amount) {
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