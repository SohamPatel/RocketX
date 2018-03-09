using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePlayerName : MonoBehaviour {
	public InputField playerNameLabel;

	void Start () {
		if (!PlayerPrefs.HasKey("PlayerName")){
			// Player preferences doesn't have username
			PlayerPrefs.SetString ("PlayerName", "Player");
		}
		playerNameLabel.text = PlayerPrefs.GetString ("PlayerName");
			
	}

	public void ChangePlayerName (string newName) {
		PlayerPrefs.SetString ("PlayerName", newName);
		Debug.Log("Name is now " + PlayerPrefs.GetString("PlayerName"));
	}
}
