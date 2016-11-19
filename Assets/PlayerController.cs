using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Rigidbody rb;
	public Text Msg;

	private int coins = 0;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();

		UpdateMsg ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) 
	{
		print (other.gameObject.tag);
		if (other.gameObject.CompareTag ("coin")) {
			other.gameObject.SetActive (false);
		} else {
			print (other.gameObject.tag);
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag ("coin")) {
			print ("Collect coin.");
			collision.gameObject.SetActive (false);
			coins++;
			UpdateMsg ();
		} else if (collision.gameObject.CompareTag ("ghost")) {
			print ("Hit by Ghost.");
			UpdateMsg (true);
		}
	}

	void UpdateMsg(bool isOver = false) {
		if (isOver) {
			Msg.text = "GAME OVER";
		} else {
			Msg.text = "Coins: " + coins;
		}
	}
}
