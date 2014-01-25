using UnityEngine;
using System.Collections.Generic;

public class Runner : MonoBehaviour {

	public static float distanceTraveled;
	private static int boosts;
	
	public float acceleration;
	public Vector3 boostVelocity, jumpVelocity, walkVelocity;
	public float gameOverY;
	
	public bool touchingPlatform;
	private Vector3 startPosition;

	public string playertype;

	public List<AudioClip> sounds;
	AudioSource aud;

	void Start () {
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
		startPosition = transform.localPosition;
		renderer.enabled = false;
		rigidbody.isKinematic = true;
		enabled = false;
		aud = GetComponent<AudioSource>();

		//touchingPlatform = true;
	}
	
	void Update () {
		//*JW horizontal
		if (playertype == "h") 
		{
				if (Input.GetAxis ("Horizontal") > 0) { 
				//if(Input.GetButtonDown("Horizontal"))
						rigidbody.AddForce (-walkVelocity, ForceMode.VelocityChange);
				}	
				//
				//*JW
				if (Input.GetAxis ("Horizontal") < 0) { 
				//if(Input.GetButtonDown("Horizontal"))
						rigidbody.AddForce (walkVelocity, ForceMode.VelocityChange);
				}	
							
				//**JW Jump

				/*
				if (Input.GetKey(KeyCode.Keypad0))
				{
					//**JW Jump
					//StartCoroutine(Jump(KeyCode.Keypad0));				
				}
				*/


			if (Input.GetKey(KeyCode.Keypad0))
				{
					if (touchingPlatform)
						//if (transform.position.y<1.6)
					{
						Debug.Log("Jump");
						rigidbody.AddForce (jumpVelocity, ForceMode.VelocityChange);
						touchingPlatform = false;
					}		
				}
		}

		//*JW vertical
		if (playertype == "v") 
		{
			if (Input.GetAxis ("Horizontal2") > 0) { 
				//Debug.Log ("test");
				//Input.GetKey(KeyCode.
				//if(Input.GetButtonDown("Horizontal"))
				rigidbody.AddForce (-walkVelocity, ForceMode.VelocityChange);
			}	
			//
			//*JW
			if (Input.GetAxis ("Horizontal2") < 0) { 
				//if(Input.GetButtonDown("Horizontal"))
				rigidbody.AddForce (walkVelocity, ForceMode.VelocityChange);
			}	

			if (Input.GetKey(KeyCode.Space))
			{
				if (touchingPlatform)
					//if (transform.position.y<1.6)
				{
					Debug.Log("Jump");
					rigidbody.AddForce (jumpVelocity, ForceMode.VelocityChange);
					touchingPlatform = false;
				}		
			}
			//**JW Jump
			//StartCoroutine(Jump(KeyCode.Space));

		}

		distanceTraveled = transform.localPosition.x;
		GUIManager.SetDistance(distanceTraveled);

		//GAME OVER CONDITION

		if(transform.localPosition.y < gameOverY){
			GameEventManager.TriggerGameOver();
		}
	}

	void FixedUpdate () {
		//if(touchingPlatform){
			rigidbody.AddForce(acceleration, 0f, 0f, ForceMode.Acceleration);
		//}
	}

	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.layer == LayerMask.NameToLayer("Floor")) {
			touchingPlatform = true;
		}
		if (collision.gameObject.layer == LayerMask.NameToLayer("Vehicles")) {
			aud.clip = sounds[5];
			aud.Play();
		}
	}

	void OnCollisionExit (Collision collision) {
		//if (collision.gameObject.tag == "Ground") {
			touchingPlatform = false;
		//}
	}

	private void GameStart () {
		boosts = 0;
		GUIManager.SetBoosts(boosts);
		distanceTraveled = 0f;
		GUIManager.SetDistance(distanceTraveled);
		transform.localPosition = startPosition;
		renderer.enabled = true;
		rigidbody.isKinematic = false;
		enabled = true;
	}
	
	private void GameOver () {
		renderer.enabled = false;
		rigidbody.isKinematic = true;
		enabled = false;
	}
	
	public static void AddBoost(){
		boosts += 1;
		GUIManager.SetBoosts(boosts);
	}


	/*
	IEnumerator Jump(KeyCode KeyPress) 
	{

		if (Input.GetKey(KeyPress))
		{
			if (touchingPlatform)
			//if (transform.position.y<1.6)
			{
				Debug.Log("Jump");
				rigidbody.AddForce (jumpVelocity, ForceMode.VelocityChange);
			}		
		}
		yield return new WaitForSeconds (0.01f);
	}
*/

/*
	IEnumerator Accelerate() 
	{

	}
*/
}