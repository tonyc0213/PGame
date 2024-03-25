using System;
using System.Collections.Generic;
using Cinemachine;
using KartGame.KartSystems;
using UnityEngine;

namespace Karting.Scripts.Utilities {
	[CreateAssetMenu(menuName = "Kart Setting")]
	public class KartSettings : ScriptableObject {

		[Serializable]
		public class KartItem {
			public string name;
			public ArcadeKart prefab;
		}
		
		public List<KartItem> karts;

		[SerializeField] KartItem _selected;

		public KartItem selected {
			get {
				if (_selected?.prefab == null) {
					_selected = karts[0];
				}

				return _selected;
			}
			set => _selected = value;
		}
	}
	

}