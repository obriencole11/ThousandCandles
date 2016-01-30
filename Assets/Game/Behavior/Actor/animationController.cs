using UnityEngine;
using System.Collections;

namespace game.behavior {
public class animationController {

		private delegate void actorState ();
		//delegate holder
		private actorState stateMethod;

		private Animator anim;
		private actorInput input;

		//class constructor
		public animationController(actorInput _input, Animator _anim)
		{
			anim = _anim;
			input = _input;
		}

		public void Start ()
		{
			stateMethod = new actorState (Idle);
		}

		public void Update ()
		{
			stateMethod ();
		}

		private void Idle () {



			if (input.verticalInput != 0.0f) {
				stateMethod = new actorState (Move);
				anim.SetTrigger ("move");
			}

			if (input.horizontalInput != 0.0f) {
				stateMethod = new actorState (Rotate);
				anim.SetTrigger ("rotate");
			}
		}
		
		private void Move () {


			if (input.verticalInput == 0) {
					stateMethod = new actorState (Idle);
					anim.SetBool ("isMoving", false);
				}
		}

		private void Rotate () {
			anim.SetBool ("isRotating", true);
			
			if (input.horizontalInput == 0) {
				stateMethod = new actorState (Idle);
				anim.SetBool ("isRotating", false);
			}
		}


		
	}
}
