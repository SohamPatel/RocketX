using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardLoader : MonoBehaviour {

	public GameObject[] scores;
	public GameObject[] names;
	// Use this for initialization
	void Start () {

//		PlayerPrefs.DeleteAll ();

		// Scan through Player preferences to find all the highscores and change the gui text to show those
		for (int i = 0; i < 10; i++) {
			if (PlayerPrefs.HasKey ("Score" + i.ToString())) {
				scores [i].GetComponent<Text>().text = PlayerPrefs.GetInt ("Score" + i.ToString ()).ToString();
				names [i].GetComponent<Text>().text = PlayerPrefs.GetString ("Name" + i.ToString ());
			} else {
				scores [i].GetComponent<Text>().text = "----";
				names [i].GetComponent<Text>().text = "------------";
			}
		}
	}
}
