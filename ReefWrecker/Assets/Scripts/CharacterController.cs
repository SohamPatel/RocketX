using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterController : MonoBehaviour {

	public float movementSpeed;
	private Rigidbody2D player;
	private bool facingRight;
	public Camera myCamera;
	private float maxWidth;
	public bool gotHit;
    public Sprite black;
    public AudioSource audio;
    private bool check;

    // Use this for initialization
    void Start () {

        // Set got hit to flase;
        check = false;
        gotHit = false;
		player = GetComponent<Rigidbody2D> ();
		facingRight = true;

		// Set camera to main if not defined
		if (myCamera == null) {
			myCamera = Camera.main;
		}

		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0);
		Vector3 targetWidth = myCamera.ScreenToWorldPoint (upperCorner);
		float characterWidth = GetComponent<CapsuleCollider2D> ().bounds.extents.x;
		maxWidth = targetWidth.x - characterWidth;

	}

	void FixedUpdate(){
		// Allow movement of character if not hit by coal
		if (gotHit == false && !IsPointerOverUIObject ()) {

			// Keyboard Controls

			float xPosition = Input.GetAxis ("Horizontal") * Time.fixedDeltaTime * movementSpeed;
			player.MovePosition (player.position + Vector2.right * xPosition);

			// Mobile Controls

			// Get rawPosition by converting screen touch location to game area location
			Vector3 rawPos = myCamera.ScreenToWorldPoint (Input.mousePosition);
			// Remove y and z values, as the character can only move in x direction
			Vector3 targetPos = new Vector3 (rawPos.x, 0, 0);
			// Lock movement to be between maxWidth of the screen
			float targetWidth = Mathf.Clamp (targetPos.x, -maxWidth, maxWidth);
			// Create the final vector position
			targetPos = new Vector3 (targetWidth, targetPos.y, targetPos.z);
			player.MovePosition (new Vector2 (targetPos.x, targetPos.y));
		} else {
			Debug.Log ("Not Moving !!!");
		}
	}

	// Called whenever the player hits a 2D Collider
	void OnCollisionEnter2D (Collision2D hit){
		if(hit.transform.gameObject.name.Contains("Coal")){
			// Set got hit to true
			gotHit = true;
            if (check == false) {
                audio.Play();
                check = true;
            }
            GetComponent<Animator>().enabled = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = black;

			// Call End Game
			FindObjectOfType<GameManager> ().EndGame ();
		}
	}

	private bool IsPointerOverUIObject() {
		PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
		eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		List<RaycastResult> results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
		return results.Count > 0;
	}
}
