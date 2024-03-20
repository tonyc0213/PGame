using KartGame.KartSystems;
using UnityEngine;

namespace KartGame.Items {
	public class WaterPuddle : MonoBehaviour {
		public float drag;
		public float angularDrag;
		
		[Tooltip("Layers to trigger with")]
		public LayerMask layerMask;

		private void OnTriggerEnter(Collider other)
		{
			if ((layerMask.value & 1 << other.gameObject.layer) > 0 && other.gameObject.CompareTag("Player")) {
				var kart = other.GetComponentInParent<ArcadeKart>();
				if (kart != null) {
					kart.SetDrag(drag, angularDrag);
				}
			}
		}
		
		private void OnTriggerExit(Collider other)
		{
			if ((layerMask.value & 1 << other.gameObject.layer) > 0 && other.gameObject.CompareTag("Player")) {
				var kart = other.GetComponentInParent<ArcadeKart>();
				if (kart != null) {
					kart.RemoveDrag();
				}
			}
		}
	}
}