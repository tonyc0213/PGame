using System;
using Karting.Scripts.Utilities;
using TMPro;
using UnityEngine;

namespace KartGame.UI {
	public class ScoreDisplay : MonoBehaviour {
		public TextMeshProUGUI score;
		public TextMeshProUGUI highScore;

		public ScoreObject ScoreObject;
		public SaveObject SaveObject;

		void Start() {
			score.text = $"Score: {ScoreObject.currentScore}";
			highScore.text = $"High Score: {SaveObject.mySave.highScore}";
		}
	}
}