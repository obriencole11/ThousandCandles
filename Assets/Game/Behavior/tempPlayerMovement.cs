using UnityEngine;
using System.Collections;

namespace game.behavior {
public class tempPlayerMovement : MonoBehaviour {

	public float speed = 10;
	// Update is called once per frame
	void Update () {
			float h = Input.GetAxis ("Horizontal");
			float v = Input.GetAxis ("Vertical");

			gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.right * h * Time.deltaTime * speed);
			gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.up * v * Time.deltaTime * speed);
	}
}
}
