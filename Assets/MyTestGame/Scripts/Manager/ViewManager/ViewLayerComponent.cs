using UnityEngine;

namespace TestGame.ViewManager
{
    public class ViewLayerComponent : MonoBehaviour
    {
        [SerializeField]
        private Transform mHudPanel;
        public Transform HudPanel => mHudPanel;

        [SerializeField]
        private Transform mViewPanel; 
        public Transform ViewPanel => mViewPanel;

        [SerializeField]
        private Transform mTopPanel;
        public Transform TopPanel => mTopPanel;
    }
}