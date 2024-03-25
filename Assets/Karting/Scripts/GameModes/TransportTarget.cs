using System;
using Karting.Scripts.Utilities;
using UnityEngine;
using UnityEngine.Events;

namespace KartGame.GameModes {
	public class TransportTarget : MonoBehaviour {
		[Tooltip("Layers to trigger with")]
		public LayerMask layerMask;
		
		public event Action OnCollect;
		public ParticlePool CollectVFX;
		public AudioClip CollectSound;
		
		void OnTriggerEnter(Collider other) {
			if ((layerMask.value & 1 << other.gameObject.layer) > 0 && other.gameObject.CompareTag("Player")) {
				OnCollect?.Invoke();
				CollectVFX.SpawnAt(transform.position);
				
				if (CollectSound) AudioUtility.CreateSFX(CollectSound, transform.position, AudioUtility.AudioGroups.Pickup, 0f);
			}
		}
	}
}