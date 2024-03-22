using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace KartGame.UI {
	public class CameraManager : MonoBehaviour {
		[Header("Third Person Camera")] 
		public Camera tpsCamera;
		public float ToTPSDelay;
		public UnityEvent OnChangeToThirdPerson;
		
		[Header("First Person Camera")] 
		public Camera fpsCamera;
		public float ToFPSDelay;
		public UnityEvent OnChangeToFirstPerson;
		
		bool isfps = false;
		bool canChangeCamera;
		void Start() {
			var gameFlowManager = GetComponent<GameFlowManager>();
			
			fpsCamera = gameFlowManager.playerKart.GetComponentInChildren<Camera>(true);
			OnChangeToThirdPerson.Invoke();
			_toggleCamera();

			canChangeCamera = true;
		}

		void Update() {
			if (Input.GetButtonDown("Camera") && canChangeCamera) {
				StartCoroutine(toggleCamera());
			}
		}

		void _toggleCamera() {
			if (isfps) {
				fpsCamera.gameObject.SetActive(true);
				tpsCamera.gameObject.SetActive(false);
			} else {
				fpsCamera.gameObject.SetActive(false);
				tpsCamera.gameObject.SetActive(true);
			}
		}

		IEnumerator toggleCamera() {
			canChangeCamera = false;
			
			isfps = !isfps;
			(isfps ? OnChangeToFirstPerson : OnChangeToThirdPerson).Invoke();
			yield return new WaitForSeconds(isfps ? ToFPSDelay : ToTPSDelay);

			canChangeCamera = true;
			_toggleCamera();
		}
	}
}