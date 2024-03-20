using System.Collections;
using System.Collections.Generic;
using KartGame.KartSystems;
using Karting.Scripts.Utilities;
using UnityEngine;

public class Obstacle : MonoBehaviour {
	public ParticlePool CollectVFX;
	
	[Header("Crash Settings")]
	[Range(0.0f, 100000.0f), Tooltip("Max Speed while boosting")]
	public float CrashForce;
	[Range(0.0f, 10.0f), Tooltip("Duration of crash")]
	public float CrashDuration;
	
	[Tooltip("Layers to trigger with")]
	public LayerMask layerMask;
	
	private void OnTriggerEnter(Collider other)
	{
		if ((layerMask.value & 1 << other.gameObject.layer) > 0 && other.gameObject.CompareTag("Player")) {
			TriggerCrash(other);
		}
	}

	void TriggerCrash(Collider other) {
		var kart = other.GetComponentInParent<ArcadeKart>();
		if (kart != null) {
			kart.Crash(CrashForce, CrashDuration);
		}
		
		if (CollectVFX) CollectVFX.SpawnAt(transform.position);
	}
}
