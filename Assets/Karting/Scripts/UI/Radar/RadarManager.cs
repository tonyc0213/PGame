using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Color = UnityEngine.Color;

namespace Karting.UI.Radar {
	public class RadarManager : MonoBehaviour {
		public static Transform origin;

		public static Action<Transform, Color> RegisterTarget;
		public static Action<Transform> UnregisterTarget;

		public float indicatorDistance;
		public Transform indicatorTemplate;
		
		Dictionary<Transform, Transform> targets = new Dictionary<Transform, Transform>();


		void Update() {
			foreach (var (target, indicator) in targets) {
				var pos = origin.InverseTransformPoint(target.position).normalized * indicatorDistance;
				pos.y = 0;
				indicator.localPosition = pos;
				var t = transform;
				indicator.localRotation = Quaternion.LookRotation(pos - t.position, t.up);
			}
		}

		void addTarget(Transform target, Color color) {
			var indicator = Instantiate(indicatorTemplate, transform);
			var image = indicator.GetComponentInChildren<Image>();
			image.color = color;
			targets.Add(target, indicator.transform);
		}
		
		void removeTarget(Transform target) {
			if(targets.TryGetValue(target, out var indicator)) {
				targets.Remove(target);
				Destroy(indicator.gameObject);
			}
		}

		void OnEnable() {
			RegisterTarget += addTarget;
			UnregisterTarget += removeTarget;
		}

		void OnDestroy() {
			RegisterTarget -= addTarget;
			UnregisterTarget -= removeTarget;
		}
	}
}