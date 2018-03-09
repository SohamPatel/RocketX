using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour {

	public Sprite musicOnImage;
	public Sprite musicOffImage;
	GameObject musicObject;
	private int savedSoundSetting;
	private static int SOUND_ON = 1;
	private static int SOUND_OFF = 0;

	// Use this for initialization
	void Start () {
		musicObject = GameObject.Find("Music");

		//Get player's preferences and set savedSoundSetting accordingly
		if (PlayerPrefs.HasKey ("MusicSetting")) {
			savedSoundSetting = PlayerPrefs.GetInt ("MusicSetting");
			Debug.Log (PlayerPrefs.GetInt ("MusicSetting"));
		} else {
			savedSoundSetting = SOUND_ON;
		}

		// Convert savedSoundSetting to bool and call functions correspondingly
		if (savedSoundSetting == SOUND_ON) {
			AudioListener.pause = false;
			ChangeMusicOnOffImage (true);
		} else {
			AudioListener.pause = true;
			ChangeMusicOnOffImage (false);
		}
	}

    public void toggle()
    {
        AudioListener.pause = !AudioListener.pause;

		// Convert bool to int and store that into savedSoundSetting
		if (AudioListener.pause == false) {
			savedSoundSetting = SOUND_ON;
		} else {
			savedSoundSetting = SOUND_OFF;
		}

		// Store savedSoundSettings into player's preferences
		PlayerPrefs.SetInt ("MusicSetting", savedSoundSetting);
		Debug.Log (PlayerPrefs.GetInt ("MusicSetting"));
		ChangeMusicOnOffImage (!AudioListener.pause);
    }

	void ChangeMusicOnOffImage(bool on)
	{
		if(on)
			musicObject.GetComponent<Image>().sprite = musicOnImage;
		else
			musicObject.GetComponent<Image>().sprite = musicOffImage;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
