using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

namespace KartGame.UI {
	public class Timer : MonoBehaviour {
		public float time;
		public UnityEvent OnTimeUp;

		float myTime;

		void Update() {
			myTime -= Time.deltaTime;
			if (myTime <= 0) {
				OnTimeUp?.Invoke();
			}
		}
		
		void OnEnable() {
			myTime = time;
		}
	}
}