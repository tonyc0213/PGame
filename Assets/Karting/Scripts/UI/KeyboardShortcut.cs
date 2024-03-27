using System;
using UnityEngine;
using UnityEngine.Events;

namespace KartGame.UI {
	public class KeyboardShortcut : MonoBehaviour {
		public KeyCode key;

		public UnityEvent OnKeyDown; 
		
		void Update() {
			if (Input.GetKeyDown(key)) {
				OnKeyDown?.Invoke();
			}
		}
	}
}