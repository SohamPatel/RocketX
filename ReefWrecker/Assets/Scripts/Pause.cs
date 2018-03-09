using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
    public bool pause;
	public GameObject pauseOverlay;

	// Use this for initialization
	void Start () {
        pause = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void onPause()
    {
        pause = !pause;
        if(!pause)
        {
            Time.timeScale = 1;
			pauseOverlay.SetActive (false);
        }
        else if(pause)
        {
            Time.timeScale = 0;
			pauseOverlay.SetActive (true);
        }
    }
}
