using System.Collections.Generic;
using UnityEngine;
using Framework;

namespace TestGame.ViewManager
{
    public class ViewManager : MonoBehaviour, IViewManager
    {
        [SerializeField]
        private Transform m_HudPanel;

        [SerializeField]
        private Transform m_ViewPanel;

        [SerializeField]
        private Transform m_TopPanel;

        private Dictionary<ViewDefine.ViewEnum, GameObject> m_ViewCaches = new Dictionary<ViewDefine.ViewEnum, GameObject>();
        private Dictionary<ViewDefine.Layer, IViewLayer> m_ViewLayers = new Dictionary<ViewDefine.Layer, IViewLayer>();

        private void Awake()
        {
            m_ViewLayers.Add(ViewDefine.Layer.HUD, new ViewHeapLayer(m_HudPanel));
            m_ViewLayers.Add(ViewDefine.Layer.View, new ViewStackLayer(m_ViewPanel));
            m_ViewLayers.Add(ViewDefine.Layer.Top, new ViewHeapLayer(m_TopPanel));

            var architecture = MyGame.Instance;
            architecture.RegisterEvent<Event.PopViewEvent>((e) => PopView(e.viewName))
                .UnRegisterWhenGameObjectDestroyed(gameObject);
            architecture.RegisterEvent<Event.PushViewEvent>((e) => PushView(e.viewName))
                .UnRegisterWhenGameObjectDestroyed(gameObject);
            architecture.RegisterEvent<Event.CloseAllViewEvent>((e) => ClearView())
                .UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private GameObject LoadGameObject(in ViewDefine.ViewInfo viewInfo)
        {
            // 暂时直接用Resources，后续考虑改为用ResourcesUtility
            var gameObject = Resources.Load<GameObject>(viewInfo.uiPath);
            return gameObject;
        }

        private bool GetViewLayer(ViewDefine.ViewEnum viewName, out IViewLayer viewLayer)
        {
            viewLayer = null;
            if (!GetViewInfo(viewName, out var viewInfo))
            {
                return false;
            }
            return GetViewLayer(viewInfo.layer, out viewLayer);
        }

        private bool GetViewLayer(ViewDefine.Layer layer, out IViewLayer viewLayer) => m_ViewLayers.TryGetValue(layer, out viewLayer);

        private bool GetViewInfo(ViewDefine.ViewEnum viewName, out ViewDefine.ViewInfo viewInfo) => ViewDefine.GetViewInfo(viewName, out viewInfo);

        private bool m_IsClearing = false;
        public bool IsClearing(bool silently = true)
        {
            if (m_IsClearing && !silently)
            {
                Debug.LogWarning("清空界面中，请误操作");
            }
            return m_IsClearing;
        }

        public void ClearView()
        {
            m_IsClearing = true;

            foreach(var viewLayer in m_ViewLayers)
            {
                viewLayer.Value.Clear();
            }

            m_IsClearing = false;
        }

        public void PushView(ViewDefine.ViewEnum viewName)
        {   
            if (IsClearing(false))
            {
                return;
            }

            if (!(GetViewInfo(viewName, out var viewInfo) && GetViewLayer(viewInfo.layer, out var viewLayer)))
            {
                return;
            }

            if (!m_ViewCaches.TryGetValue(viewName, out GameObject viewPrefab))
            {
                viewPrefab = LoadGameObject(in viewInfo);
                m_ViewCaches[viewName] = viewPrefab;
            }

            var viewObject = Instantiate(viewPrefab);
            var view = viewObject.GetComponent<IView>();
            view.SetViewName(viewName);
            view.SetViewManager(this);
            viewLayer.Push(view);
        }

        public void PopView(ViewDefine.ViewEnum viewName)
        {
            if (IsClearing(false) || !GetViewLayer(viewName, out var viewLayer))
            {
                return;
            }
            viewLayer.Pop(viewName);
        }

        public void PopView(IView view)
        {
            if (IsClearing(false) || !GetViewLayer(view.ViewName, out var viewLayer))
            {
                return;
            }
            viewLayer.Pop(view);
        }
    }
}