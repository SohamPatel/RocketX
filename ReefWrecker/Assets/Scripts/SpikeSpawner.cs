using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpikeSpawner : MonoBehaviour {

	public Transform[] spawnLocations;
	public GameObject spikePrefab;
	public float timeBetweenSpawn = 1f;
	private float spawnTime = 2f;
	public int score = -1;
	public Text scoreLabel;

	void Start () {
		if (score == -1) {
			scoreLabel.text = "Score: 0";
		}
	}

	void Update () {
		if (Time.time >= spawnTime) {
			spawnSpikes ();
			score++;
			scoreLabel.text = "Score: " + score.ToString ();
			Debug.Log ("Score/Wave " + score);
			spawnTime = Time.time + timeBetweenSpawn;
		}
	}

	void spawnSpikes () {
		int removePoint = Random.Range (0, spawnLocations.Length);
		for (int i = 0; i < spawnLocations.Length; i++) {
			if (removePoint != i) {
				Instantiate (spikePrefab, spawnLocations[i].position, Quaternion.identity);
			}
		}
	}

	int getScore(){
		return score;
	}
}
