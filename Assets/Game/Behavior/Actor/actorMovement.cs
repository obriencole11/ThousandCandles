using UnityEngine;
using System.Collections;

namespace game.behavior {
public class actorMovement{

		//speed variable
		public float speed { get; private set; }
		public float rotateSpeed { get; private set; }
		//transform to move
		public Transform transformObj {get; private set;}

		private Vector3 _currentPos;
		//The current position to place the player
		public Vector3 currentPos {
			get {
				return _currentPos;
			}
			private set {
				_currentPos = value;
			}
		}

		private actorInput input;
		public Vector3 targetPos;
		private Quaternion targetRot;
		public bool busy = false;

		private delegate void movementState ();
		//delegate holder
		private movementState stateMethod;

		//class constructor
		public actorMovement(float _speed, float _rotateSpeed, Transform _transform, actorInput _input)
		{
			speed = _speed;
			rotateSpeed = _rotateSpeed;
			transformObj = _transform;
			input = _input;

		}


		public void Start() {
			targetPos = transformObj.position;
			targetRot = transformObj.localRotation;
			transformObj.position = targetPos;
			stateMethod = idle;
		}

		public void Update() {
			stateMethod ();
		}

		public void flipPlayer (float dir) {
			stateMethod = rotate;
			targetRot.eulerAngles = new Vector3 (transformObj.rotation.eulerAngles.x, transformObj.rotation.eulerAngles.y + (90), transformObj.rotation.eulerAngles.z);
		}
		
		private void rotate() {

			transformObj.rotation = Quaternion.RotateTowards(transformObj.rotation, targetRot, Time.deltaTime * rotateSpeed);

			if (input.horizontalInput == 0 && VectorEqual(targetRot.eulerAngles, transformObj.rotation.eulerAngles)) {
				stateMethod = idle;
			}
		}

		private void move() {
			transformObj.position = Vector3.MoveTowards(transformObj.position, targetPos, Time.deltaTime * speed);

			if (input.verticalInput == 0 && VectorEqual(transformObj.position, targetPos) ) {
				checkGround();
			}
			
		}

		private void idle() {
			if (input.verticalInput != 0) {
				if (!checkCollision(input.verticalInput)) {
					stateMethod = move;
					targetPos = transformObj.position + transformObj.forward * input.verticalInput;
				} else {
					stateMethod = bump; 
					targetPos = transformObj.position;
				}
			} else if (input.horizontalInput != 0) {
				targetRot.eulerAngles = new Vector3 (transformObj.rotation.eulerAngles.x, transformObj.rotation.eulerAngles.y + (90 * input.horizontalInput), transformObj.rotation.eulerAngles.z);
				stateMethod = rotate;
			}
		}

		private void bump() {

			if (input.verticalInput == 0) {
				stateMethod = idle;
			}
		}





		private bool checkCollision(float input){
			Vector3 fwd = transformObj.TransformDirection(Vector3.forward) * input;

			//check for walls
			if (Physics.Raycast (transformObj.position, fwd, 1.0f)) {
				return true;
			}

			RaycastHit hit;

			if (Physics.Raycast( transformObj.position, fwd, out hit, 2.0f )) {
				if (hit.collider.tag == "Player") {
					return true;
				} 
			}
			return false;

		}

		private void checkGround() {
			RaycastHit hit;
			if (Physics.Raycast (transformObj.position, -transformObj.up, out hit, 1.0f)) {

				hit.collider.gameObject.SendMessage ("OnContact", transformObj.gameObject);
				stateMethod = idle;
			} else {
				stateMethod = idle;
			}
		}
		
		public bool VectorEqual(Vector3 a, Vector3 b){
			return Vector3.SqrMagnitude(a - b) < 0.00001;
		}

		
	}
}
