﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void toggle()
    {
        AudioListener.pause = !AudioListener.pause;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
