using UnityEngine;

namespace TestGame.ViewManager
{
    [CreateAssetMenu(menuName = "Tools/View Manager Setting", fileName = "ViewManagerSetting")]
    public class ViewManagerSetting : ScriptableObject
    {
        public ViewLayerComponent ViewLayerPrefab;
    }
}