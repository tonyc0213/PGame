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
			public GameObject displayModel;
		}

		public List<KartItem> karts;

		public KartItem selected => karts[_selectedIndex];

		[SerializeField] int _selectedIndex;
		public int selectedIndex {
			get => _selectedIndex;
			set {
				_selectedIndex = value;
				OnSelectedKartChange?.Invoke(_selectedIndex);
			}
		}
		public event Action<int> OnSelectedKartChange;
	}
}