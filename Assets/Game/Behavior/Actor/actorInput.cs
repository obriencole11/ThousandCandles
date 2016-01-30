using UnityEngine;
using System.Collections;

namespace game.behavior {
public class actorInput {

		private bool autoControls = false;

		private float _horizontalInput = 0;
		private float _verticalInput = 0;

		public float horizontalInput {
			get {
				return _horizontalInput;
			}
			private set {}
		}

		public float verticalInput {
			get {
				return _verticalInput;
			}
			private set {}
		}

		public void SafeSetHorizontalInput(float input){ 
			autoControls = true;
			_horizontalInput = input;

		}

		public void Update() {
			if (!autoControls) {
				_horizontalInput = Input.GetAxisRaw ("Horizontal");
				_verticalInput = Input.GetAxisRaw ("Vertical");
			}
			autoControls = false;
		
		}
		
}
}
