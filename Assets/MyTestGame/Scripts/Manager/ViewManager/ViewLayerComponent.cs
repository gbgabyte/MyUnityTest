using UnityEngine;

namespace TestGame.ViewManager
{
    public class ViewLayerComponent : MonoBehaviour
    {
        [SerializeField]
        private Transform m_HudPanel;
        public Transform HudPanel => m_HudPanel;

        [SerializeField]
        private Transform m_ViewPanel; 
        public Transform ViewPanel => m_ViewPanel;

        [SerializeField]
        private Transform m_TopPanel;
        public Transform TopPanel => m_TopPanel;
    }
}