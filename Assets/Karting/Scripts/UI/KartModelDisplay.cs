using System;
using System.Collections.Generic;
using Karting.Scripts.Utilities;
using UnityEngine;

namespace KartGame.UI {
	public class KartModelDisplay : MonoBehaviour {
		public KartSettings kartSetting;

		Dictionary<int, GameObject> models = new Dictionary<int, GameObject>();

		void Start() {
			var myTransform = transform;
			for (var index = 0; index < kartSetting.karts.Count; index++) {
				var kart = kartSetting.karts[index];
				var k = Instantiate(kart.displayModel, myTransform);
				models.Add(index, k);
			}

			kartSetting.OnSelectedKartChange += UpdateCurrentKart;
			UpdateCurrentKart(kartSetting.selectedIndex);
		}

		void UpdateCurrentKart(int currentIndex) {
			foreach (var (index, kart) in models) {
				kart.SetActive(index == currentIndex);
			}
		}
	}
}