using UnityEngine;

namespace KartGame.GameModes {
	public class TransportObject : TargetObject {
		[Header("TransportTargets")]
		public TransportTarget transportStart;
		public TransportTarget transportEnd;
		
		void Start() {
			Register();
			
			transportStart.gameObject.SetActive(true);
			transportStart.OnCollect += OnTransportStart;
			
			transportEnd.gameObject.SetActive(false);
			transportEnd.OnCollect += OnTransportEnd;
		}

		void OnTransportStart() {
			Debug.Log("OnTransportStart");
			transportStart.gameObject.SetActive(false);
			transportEnd.gameObject.SetActive(true);
		}

		void OnTransportEnd() {
			Debug.Log("OnTransportEnd");
			
			transportEnd.gameObject.SetActive(false);
			Objective.OnUnregisterPickup(this);
			
			TimeManager.OnAdjustTime(TimeGained);
		}
	}
}