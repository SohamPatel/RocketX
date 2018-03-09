using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour {

	public float slowDownMultiplier = 10f;
	private int newScore;
	private int[] scores;
	private string[] names;
	private static int MAX_SCORES = 10;
	public int numEndGameCall = 0;
	private int adsCounter;

	void Start () {
		scores = new int[MAX_SCORES];
		names = new string[MAX_SCORES];

		// Initialise the scores and names array
		for (int i = 0; i < MAX_SCORES; i++) {
			if (PlayerPrefs.HasKey ("Score" + i.ToString ())) {
				scores [i] = PlayerPrefs.GetInt ("Score" + i.ToString ());
				names [i] = PlayerPrefs.GetString ("Name" + i.ToString ());
			} else {
				break;
			}
		}

		//Get the number of times game player before ads needs to be showed (it is shown when the adscounter = 2)
		if (PlayerPrefs.HasKey ("AdsCounter")) {
			adsCounter = PlayerPrefs.GetInt ("AdsCounter");
		} else {
			adsCounter = 0;
		}
	}

	public void EndGame(){
		if (numEndGameCall != 0) {
			return;
		}
		numEndGameCall++;
		Debug.Log ("End Game has be CALLED!!!!");
		// Get the current round's score from another GameObject
		newScore = GameObject.Find("SpikeSpawner").GetComponent<SpikeSpawner>().score;
		Debug.Log ("New score is " + newScore);

		// Add the new score to the Leaderboard if possible
		if (scores.Length == MAX_SCORES) {
			// Full leaderboard, check if the newScore can be added to it
			for (int i = 0; i < MAX_SCORES; i++) {
				if (newScore > scores[i]) {
					int replaceIndex = i;

					// Now shift down everything
					for (int j = MAX_SCORES - 1; j >= replaceIndex; j--) {
						try {
							scores [j + 1] = scores [j];
							names [j + 1] = names [j];
						} catch (System.Exception ex) {
							continue;
						}
					}

					// Assign the new score into the replaceIndex
					scores[replaceIndex] = newScore;
					names[replaceIndex] = PlayerPrefs.GetString("PlayerName");

					break;
				}
			}
		} else {
			int emptyIndex = scores.Length;
			scores[emptyIndex] = newScore;
			names[emptyIndex] = PlayerPrefs.GetString("PlayerName");
		}

		// Save the new Leaderboard
		for (int i = 0; i < MAX_SCORES; i++) {
			if ((scores [i] == 0) || (names [i] == null)) {
				break;
			} else {
				PlayerPrefs.SetInt ("Score" + i.ToString (), scores [i]);
				PlayerPrefs.SetString ("Name" + i.ToString (), names [i]);
			}
		}

		StartCoroutine (RestartLevel ());
	}

	IEnumerator RestartLevel(){
		Time.timeScale = 1f / slowDownMultiplier;
		Time.fixedDeltaTime = Time.fixedDeltaTime / slowDownMultiplier;

		yield return new WaitForSeconds (1f / slowDownMultiplier);

		Time.timeScale = 1f;
		Time.fixedDeltaTime = Time.fixedDeltaTime * slowDownMultiplier;

		//Check if Ads need to be called
		if (adsCounter == 2) {
			adsCounter = 0;
			// Call Ad here
			Advertisement.Show();
			PlayerPrefs.SetInt ("AdsCounter", adsCounter);
		} else {
			adsCounter++;
			PlayerPrefs.SetInt ("AdsCounter", adsCounter);
		}
		//Debug.Log ("Ad counter is now " + adsCounter.ToString());
		SceneManager.LoadScene ("Leaderboard");
	}
}
