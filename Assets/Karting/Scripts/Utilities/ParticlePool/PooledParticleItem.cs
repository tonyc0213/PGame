using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Karting.Scripts.Utilities {
	public class PooledParticleItem : MonoBehaviour {
		public ParticleSystem particle { get; set; }
		PoolObjectDef myPool;
		
		void Awake() {
			particle = GetComponent<ParticleSystem>();
		}

		void OnParticleSystemStopped() {
			recycle();
		}

		public void setPool(PoolObjectDef pool) {
			Assert.IsFalse(myPool != null, "Particle already belongs to another pool");
			myPool = pool;
		}

		void recycle() {
			if (myPool != null) {
				myPool.returnObject(gameObject, true);
			}
		}

		void OnValidate() {
			Assert.IsTrue(GetComponent<ParticleSystem>(), "Missing Particle System");
		}
	}
}