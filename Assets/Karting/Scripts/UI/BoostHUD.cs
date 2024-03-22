using UnityEngine;

namespace KartGame.UI {
	public class BoostHUD : MonoBehaviour {
		public GameObject BoostIndicator;

		GameFlowManager m_GameFlowManager;
		void Start() {
			m_GameFlowManager = FindObjectOfType<GameFlowManager>();
			DebugUtility.HandleErrorIfNullFindObject<GameFlowManager, FeedbackFlashHUD>(m_GameFlowManager, this);
			
			m_GameFlowManager.playerKart.OnBoostAvailableChange += x => BoostIndicator.SetActive(x);
		}
	}
}