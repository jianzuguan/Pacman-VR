using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	public Rigidbody rb;

	private Vector3[] directions;

	private float speed;
	private int direction;
	private int status;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();

		speed = 10;
		direction = 1;
		status = 1;

		directions = new Vector3[4];
		directions[0] = Vector3.forward;
		directions[1] = Vector3.back;
		directions[2] = Vector3.left;
		directions[3] = Vector3.right;
	}

	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate () {
		bool foundUser = false;

		// try find the player, if player found then chase the player
		for (int i = 0; i < 4; i++) {
			RaycastHit hit;

			if (Physics.Raycast (transform.position, directions[i], out hit, 10)) {
				
				if (hit.transform.gameObject.tag == "player") {
					foundUser = true;
					direction = i;
					break;
				}
			}
		}

		// if player not found, find available directions to go
		if (!foundUser) {
			int randomInt = Random.Range(0,10000);
			if (randomInt > 9900) {
				changeDirection ();
			}

		}

		rb.AddForce (directions [direction] * speed);
	}

	void OnCollisionEnter(Collision collision)
	{
		print("Hit Wall");
		changeDirection (true);
	}

	void changeDirection(bool isHit = false) {

		bool[] availableDirections = new bool[4];
		availableDirections [0] = true;
		availableDirections [1] = true;
		availableDirections [2] = true;
		availableDirections [3] = true;

		for (int i = 0; i < 4; i++) {
			RaycastHit hit;

			if (Physics.Raycast (transform.position, directions[i], out hit, 1)) {
				if (hit.transform.gameObject.tag == "wall") {
					print("Has Wall");
					availableDirections [i] = false;
				}
			}
		}
			
		// avoid going back if going forward is available
		if (!isHit && availableDirections[direction] == true) {
			if (direction == 0) {
				availableDirections [1] = false;
			} else if (direction == 1) {
				availableDirections [0] = false;
			} else if (direction == 2) {
				availableDirections [3] = false;
			} else if (direction == 3) {
				availableDirections [2] = false;
			}
		}

		// choose a random direction from the available directions list
		int randomIndex = Random.Range(0,4);
		while(!availableDirections[randomIndex]) {
			randomIndex = Random.Range(0,4);
		}
		direction = randomIndex;
//		print ("randomIndex: "+randomIndex+"-direction: "+direction);
	}

	bool[] GetAvailableDirections() {

		bool[] availableDirections = new bool[4];
		availableDirections [0] = true;
		availableDirections [1] = true;
		availableDirections [2] = true;
		availableDirections [3] = true;

		for (int i = 0; i < 4; i++) {
			RaycastHit hit;

			if (Physics.Raycast (transform.position, directions[i], out hit, 1)) {
				if (hit.transform.gameObject.tag == "wall") {
					availableDirections [i] = false;
				}
			}
		}

		return availableDirections;
	}

	int randomDirection() {
		return 1;
	}
}
