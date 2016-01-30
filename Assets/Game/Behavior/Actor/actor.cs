using UnityEngine;
using System.Collections;
using System;
using System.Reflection;

namespace game.behavior {
public class actor : MonoBehaviour {
	
	//characteristics of all actors
	public float speed = 10;
	public float rotateSpeed = 100;

	public actorMovement _actorMovement;
	private Action movementUpdate = ()=>{};
	private Action animationUpdate = ()=>{};
	private Action inputUpdate = ()=>{};

	public actorInput _actorInput;
	private animationController _animationController;

	private Action update = ()=>{};

		// Use this for initialization
	void Start() {
		_actorInput = new actorInput ();
		_actorMovement = new actorMovement (speed, rotateSpeed, gameObject.transform, _actorInput);
		_animationController = new animationController (_actorInput, gameObject.GetComponent<Animator>());

		Action movementStart = ()=>{};
		Action animationStart = ()=>{};
		movementStart = GetAction (_actorMovement, "Start");
		animationStart = GetAction (_animationController, "Start");
		movementStart ();
		animationStart ();

		movementUpdate = GetAction (_actorMovement, "Update");
		animationUpdate = GetAction (_animationController, "Update");
		inputUpdate = GetAction (_actorInput, "Update");
		
		
		}
	
	void Update() {
			inputUpdate ();
			movementUpdate ();
			animationUpdate ();
	}

	private Action GetAction(System.Object classObj, string searchTerm) {
			MethodInfo mi= classObj.GetType().GetMethod(searchTerm, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
			
			if (mi != null) {
				Action tempAction = (Action)Delegate.CreateDelegate (typeof(Action), classObj, mi);
				return tempAction;
			} else {
				return null;
			}
	}


}
}
