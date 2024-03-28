using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Karting.Scripts.Utilities {
	[CreateAssetMenu(menuName = "Save Object")]
	public class SaveObject : ScriptableObject {
		[Serializable]
		public class SaveItem {
			public bool hasShownIntro;
			public List<string> unlockedItems;
			public int highScore;
		}

		SaveItem _mySave;

		public SaveItem mySave {
			get {
				if (_mySave == null) {
					loadSave();
				}

				return _mySave;
			}
		}

		string savePath => $"{Application.persistentDataPath}/GamePrefs.json";
		
		public void loadSave() {
			Debug.Log($"Loading save from {savePath}");
			if (File.Exists(savePath)) {
				string fileContents = File.ReadAllText(savePath);
				_mySave = JsonUtility.FromJson<SaveItem>(fileContents);
			} else {
				_mySave = new SaveItem() { unlockedItems = new List<string>(), highScore = 0 };
			}
		}

		public void writeSave() {
			Debug.Log($"Writing save to {savePath}");
			
			string jsonString = JsonUtility.ToJson(mySave);
			File.WriteAllText(savePath, jsonString);
		}
	}
}