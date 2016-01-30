using UnityEngine;
using System.Collections;
using System;

namespace game.behavior.enviroment {
public class platform : ground {
	
	//private actorMovement _actorMovement;
	private float flipDir = 1;
	
	public platform (float dir){
		flipDir = dir;
	}
	
	public void Start() {
		contactMethod = flip;
	}

	public void flip (GameObject sender) {

		//sender.GetComponent<actor> ()._actorMovement.flipPlayer (flipDir);
	}
}
}
