using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpikeManager : MonoBehaviour {
	private Rigidbody2D spike;
	private float gravityScaleMultiplier = 20f;
    public AudioSource audio;
    private bool check;
	private int score;

    // Use this for initialization
    void Start () {
        check = false;
		spike = GetComponent<Rigidbody2D> ();
		score = GameObject.Find("SpikeSpawner").GetComponent<SpikeSpawner>().score;
		spike.gravityScale += score / gravityScaleMultiplier;
    }

	// Update is called once per frame
	void Update () {
		if (transform.position.y < -3.74f) {
            if (check == false)
            {
                audio.Play();
                check = true;
            }
            StartCoroutine (WaitBeforeRemove());
        }
	}

	IEnumerator WaitBeforeRemove(){
        yield return new WaitForSeconds(1f);
        Destroy (gameObject);
    }
}
