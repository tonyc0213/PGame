using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DigitalRuby.RainMaker;
using UnityEngine;
using UnityEngine.Events;

namespace KartGame.UI {
	public class CameraManager : MonoBehaviour {
		public CinemachineVirtualCamera cinemachine;
		
		[Header("Third Person Camera")] 
		public Camera tpsCamera;
		public float ToTPSDelay;
		public UnityEvent OnChangeToThirdPerson;
		
		[Header("First Person Camera")] 
		public Camera fpsCamera;
		public float ToFPSDelay;
		public UnityEvent OnChangeToFirstPerson;

		public RainScript rain;

		public List<Canvas> ScreenSpaceCanvases;

		bool isfps = false;
		bool canChangeCamera;
		void Start() {
			var gameFlowManager = GetComponent<GameFlowManager>();
			var playerKartTransform = gameFlowManager.playerKart.transform;

			cinemachine.Follow = playerKartTransform;
			var capsule = playerKartTransform.Find("KartBouncingCapsule");
			cinemachine.LookAt = capsule ? capsule : playerKartTransform;

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

				foreach (var canvas in ScreenSpaceCanvases) {
					canvas.worldCamera = fpsCamera;
				}
				rain.Camera = fpsCamera;
			} else {
				fpsCamera.gameObject.SetActive(false);
				tpsCamera.gameObject.SetActive(true);
				
				foreach (var canvas in ScreenSpaceCanvases) {
					canvas.worldCamera = tpsCamera;
				}
				rain.Camera = tpsCamera;
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