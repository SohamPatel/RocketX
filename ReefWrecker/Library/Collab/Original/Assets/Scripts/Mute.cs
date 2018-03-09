using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour {

	public Sprite musicOnImage;
	public Sprite musicOffImage;
	GameObject musicObject;

	// Use this for initialization
	void Start () {
		musicObject = GameObject.Find("Music");
		ChangeMusicOnOffImage (!AudioListener.pause);
	}

    public void toggle()
    {
        AudioListener.pause = !AudioListener.pause;
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
