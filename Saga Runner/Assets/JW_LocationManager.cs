using UnityEngine;
using System.Collections;

public class JW_LocationManager : MonoBehaviour {
	public GameObject hPlayer, vPlayer;
	public Vector3 boostVelocity;

	//max distance before the rubber banding happens
	public float MaxDistance =15f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine("Slow");

		//Debug.Log("Distance =" + Vector3.Distance(hPlayer.transform.position, vPlayer.transform.position)+
		 //         "   hPlayer x =" + hPlayer.transform.position.x);

	}

	IEnumerator Slow() 
	{
		yield return new WaitForSeconds(3f);

		if (Vector3.Distance(hPlayer.transform.position, vPlayer.transform.position)>MaxDistance)
		{
			
			if (hPlayer.transform.position.x>vPlayer.transform.position.x)			     
			{
				Debug.Log("speed up vPlayer");
				hPlayer.rigidbody.velocity = vPlayer.rigidbody.velocity; 
				hPlayer.rigidbody.velocity /=1.1f;
				//hPlayer.rigidbody.velocity = vPlayer.rigidbody.velocity; 
				//hPlayer.rigidbody.AddForce(-boostVelocity, ForceMode.VelocityChange);
				//vPlayer.rigidbody.AddForce(boostVelocity, ForceMode.VelocityChange);
			}
			else
			{
				Debug.Log("speed up hPlayer");
				vPlayer.rigidbody.velocity = hPlayer.rigidbody.velocity; 
				vPlayer.rigidbody.velocity /=1.1f;
				//vPlayer.rigidbody.velocity = hPlayer.rigidbody.velocity; 
				//vPlayer.rigidbody.AddForce(-boostVelocity, ForceMode.VelocityChange);

				//hPlayer.rigidbody.AddForce(boostVelocity, ForceMode.VelocityChange);
			}
		}
	}
}
