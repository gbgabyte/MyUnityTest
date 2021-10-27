using System.Collections.Generic;
using UnityEngine;
using Framework;
using TestGame.Event;

namespace TestGame.ViewManager
{
    public class ViewManager : MonoBehaviour, IViewManager, IBelongArchiecture, ICanRegisterEvent, ICanGetUtility
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

            this.RegisterEvent((in PopViewEvent e) => PopView(e.viewName))
                .UnRegisterWhenGameObjectDestroyed(gameObject);
            this.RegisterEvent((in PushViewEvent e) => PushView(e.viewName))
                .UnRegisterWhenGameObjectDestroyed(gameObject);
            this.RegisterEvent((in CloseAllViewEvent e) => ClearView())
                .UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private GameObject LoadPrefab(in ViewDefine.ViewInfo viewInfo)
        {
            return this.GetUtility<Utility.IResourcesUtility>().Load<GameObject>(viewInfo.uiPath);
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
                viewPrefab = LoadPrefab(in viewInfo);
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

        IArchitecture IBelongArchiecture.GetArchitecture()
        {
            return MyGame.Instance;
        }
    }
}