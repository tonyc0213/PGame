using KartGame.KartSystems;
using Karting.Scripts.Utilities;
using UnityEngine;

namespace KartGame.Items {
	public class Boost : MonoBehaviour {
		public ParticlePool CollectVFX;
		
		[Tooltip("Layers to trigger with")]
		public LayerMask layerMask;
	
		private void OnTriggerEnter(Collider other)
		{
			if ((layerMask.value & 1 << other.gameObject.layer) > 0 && other.gameObject.CompareTag("Player")) {
				var kart = other.GetComponentInParent<ArcadeKart>();
				if (kart != null) {
					kart.BoostAvailable = true;
					if (CollectVFX) CollectVFX.SpawnAt(transform.position);
					gameObject.SetActive(false);
				}
			}
		}
	}
}