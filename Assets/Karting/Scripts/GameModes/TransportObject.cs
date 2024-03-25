using Karting.UI.Radar;
using UnityEngine;

namespace KartGame.GameModes {
	public class TransportObject : TargetObject {
		[Header("TransportTargets")]
		public TransportTarget transportStart;
		public Color startIndicatorColor;
		public TransportTarget transportEnd;
		public Color endIndicatorColor;
		
		void Start() {
			Register();
			
			transportStart.gameObject.SetActive(true);
			transportStart.OnCollect += OnTransportStart;
			RadarManager.RegisterTarget?.Invoke(transportStart.transform, startIndicatorColor);
			
			transportEnd.gameObject.SetActive(false);
			transportEnd.OnCollect += OnTransportEnd;
		}

		void OnTransportStart() {
			transportStart.gameObject.SetActive(false);
			transportEnd.gameObject.SetActive(true);
			
			RadarManager.UnregisterTarget?.Invoke(transportStart.transform);
			RadarManager.RegisterTarget?.Invoke(transportEnd.transform, endIndicatorColor);
		}

		void OnTransportEnd() {
			transportEnd.gameObject.SetActive(false);
			RadarManager.UnregisterTarget?.Invoke(transportEnd.transform);
			Objective.OnUnregisterPickup(this);
			
			TimeManager.OnAdjustTime(TimeGained);
		}
	}
}