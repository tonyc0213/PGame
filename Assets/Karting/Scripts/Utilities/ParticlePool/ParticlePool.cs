using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Karting.Scripts.Utilities {
	[CreateAssetMenu(menuName = "Pool/Particle")]
	public class ParticlePool : PoolObjectDef {
		public void SpawnAt(Vector3 position) {
			GameObject go = getObject(true, null);
			go.transform.position = position;

			var p = go.GetComponent<PooledParticleItem>();
			p.particle.Play();
		}

		void OnValidate() {
			Assert.IsTrue(poolObject.GetComponent<PooledParticleItem>(), "Missing Component PooledParticleItem");
		}
	}
}