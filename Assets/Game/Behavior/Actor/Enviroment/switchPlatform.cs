using UnityEngine;
using System.Collections;

namespace game.behavior.enviroment {
public class switchPlatform : MonoBehaviour {

	public float switchDirection = 1;
	private platform _platform;
	// Use this for initialization
	void Start () {
		_platform = new platform (switchDirection);
	}
	
	// Update is called once per frame
	void OnContact(GameObject sender) {
		_platform.OnContact (sender);
			sender.GetComponent<actor> ()._actorInput.SafeSetHorizontalInput (-1);
	}
}
}
