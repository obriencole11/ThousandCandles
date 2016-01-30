using UnityEngine;
using System.Collections;

namespace game.behavior.enviroment {
public class endPlatform : MonoBehaviour {

	void OnContact(GameObject sender) {

		sender.GetComponent<actor> ()._actorInput.SafeSetHorizontalInput (-1);
	}
}
}
