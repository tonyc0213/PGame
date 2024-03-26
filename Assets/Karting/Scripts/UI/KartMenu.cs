using System;
using Karting.Scripts.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KartGame.UI {
	public class KartMenu : MonoBehaviour{
		public KartSettings kartSetting;

		public TextMeshProUGUI text;

		void Start() {
			kartSetting.OnSelectedKartChange += x => UpdateName();
			UpdateName();
		}

		void UpdateName() {
			text.text = kartSetting.selected.name;
		}
		
		public void ChangeToNextKart() {
			kartSetting.selectedIndex = (kartSetting.selectedIndex + 1) % kartSetting.karts.Count;
		}
		
		public void ChangeToPrevKart() {
			var kartCount = kartSetting.karts.Count;
			kartSetting.selectedIndex = (kartCount + kartSetting.selectedIndex - 1) % kartCount;
		}
	}
}