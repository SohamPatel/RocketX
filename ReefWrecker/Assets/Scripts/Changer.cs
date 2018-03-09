using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changer : MonoBehaviour {
    public Sprite play;
    public Sprite pause;

	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = pause;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = play;
        }
        if (Time.timeScale == 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = pause;
        }
    }
}
