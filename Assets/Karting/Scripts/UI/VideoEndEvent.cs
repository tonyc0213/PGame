using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

namespace KartGame.UI {
	public class VideoEndEvent : MonoBehaviour {
		public UnityEvent OnVideoEnd;
		
		void Start() {
			var videoPlayer = GetComponent<VideoPlayer>();
			if (videoPlayer != null) {
				videoPlayer.loopPointReached += _ => OnVideoEnd?.Invoke();
			}
		}
	}
}