using UnityEngine;
using System.Collections;

public class JW_TopGravity : MonoBehaviour {
	public float gravity = 1.0F;
	// Use this for initialization
	void Start () {
		//positive number is opposite, i.e. up -ve is down
		Physics.gravity = new Vector3(0, gravity, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
