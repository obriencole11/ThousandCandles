using UnityEngine;
using System.Collections;

namespace game.behavior {
public class tempPlayerMovement : MonoBehaviour {

	public float speed = 100;
	// Update is called once per frame
	void Update () {
			float h = Input.GetAxis ("Horizontal");
			float v = Input.GetAxis ("Vertical");

			//gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.right * h * Time.deltaTime * speed);
			//gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.forward * v * Time.deltaTime * speed);

			transform.Translate (new Vector3( (h * Time.deltaTime * speed),(0) ,(v * Time.deltaTime * speed)) );
	}
}
}
