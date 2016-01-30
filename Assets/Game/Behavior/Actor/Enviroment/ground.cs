using UnityEngine;
using System.Collections;
using System;

namespace game.behavior.enviroment {
public class ground {

	public delegate void _contactMethod (GameObject sender);
	//delegate holder
	protected _contactMethod contactMethod;

	public void OnContact(GameObject sender) {
		if (contactMethod != null) {
			contactMethod (sender);
		}
	}
}
}
