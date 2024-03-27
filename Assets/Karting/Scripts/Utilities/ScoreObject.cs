using System;
using UnityEngine;

namespace Karting.Scripts.Utilities {
	[CreateAssetMenu(menuName = "Score Object")]
	public class ScoreObject : ScriptableObject {
		[NonSerialized] public int currentScore;
	}
}