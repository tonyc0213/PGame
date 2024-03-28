using System;
using UnityEngine;

namespace Karting.Scripts.Utilities {
	public class SaveInitializer : MonoBehaviour {
		public SaveObject saveObject;

		public GameObject intro;
		
		void Awake() {
			if (saveObject != null && saveObject.mySave != null) {
				saveObject.loadSave();
			}
		}

		void Start() {
			if (!saveObject.mySave.hasShownIntro) {
				intro.SetActive(true);
				
				saveObject.mySave.hasShownIntro = true;
				saveObject.writeSave();
			}
		}
	}
}