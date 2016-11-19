using UnityEngine;
using System.Collections;

public class MoveRight : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector3 move = new Vector3(10f, 0f, 0f);
		gameObject.GetComponent<Rigidbody>().AddForce (move);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
