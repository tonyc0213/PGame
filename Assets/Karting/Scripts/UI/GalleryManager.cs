using System;
using Karting.Scripts.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace KartGame.UI {
	public class GalleryManager : MonoBehaviour {
		public SaveObject SaveObject;

		void Awake() {
			var buttons = GetComponentsInChildren<Button>();

			foreach (var button in buttons) {
				var unlocked = SaveObject.mySave.unlockedItems;
				button.interactable = unlocked.Contains(button.name);
			}
		}
	}
}