using UnityEngine;
using System.Collections;



public class JW_Spawner : MonoBehaviour {
	public GameObject hPlayer, vPlayer;
	public GameObject Obstacle;
	public float vOffset, hOffset;
	// Use this for initialization
	void Start () {
		StartCoroutine(Spawn());
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 myOffset = new Vector3( 10, 0, 0 );
		//gameObject.transform.position = hPlayer.transform.position+myOffset;

			if (hPlayer.transform.position.x > vPlayer.transform.position.x) {

				gameObject.transform.position = 
				new Vector3(hPlayer.transform.position.x + 10, 2 ,0);

					//gameObject.transform.position.x, transform.position.y+0.4f, gameObject.transform.position.z);


				//hPlayer.transform.position + myOffset;
			} 
			else {
				gameObject.transform.position = 
				new Vector3(vPlayer.transform.position.x + 10, 2 ,0);
			}


	}



	IEnumerator Spawn()
	{
		//float vOffset, hOffset;

		while(true)
		{
			yield return new WaitForSeconds(Random.Range (2,6));
			vOffset = Random.Range (0, 2);
			hOffset = Random.Range (-5, 5);
			Vector3 bulletOffset = new Vector3( 0, vOffset, hOffset);

			Instantiate(Obstacle, transform.position+bulletOffset, transform.rotation);
		}
	}
}