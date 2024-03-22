using System;
using UnityEngine;

namespace KartGame.UI {
	public class CameraManager : MonoBehaviour {
		[Header("Camera")] 
		public Camera tpsCamera;
		public Camera fpsCamera;
		bool isfps = false;

		void Start() {
			var gameFlowManager = GetComponent<GameFlowManager>();
			
			fpsCamera = gameFlowManager.playerKart.GetComponentInChildren<Camera>(true);
			toggleCamera();
		}

		void Update() {
			if (Input.GetButtonDown("Camera")) {
				isfps = !isfps;
				toggleCamera();
			}
		}

		void toggleCamera() {
			if (isfps) {
				fpsCamera.gameObject.SetActive(true);
				tpsCamera.gameObject.SetActive(false);
			} else {
				fpsCamera.gameObject.SetActive(false);
				tpsCamera.gameObject.SetActive(true);
			}
		}

	}
}