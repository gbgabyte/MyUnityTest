using System.Collections.Generic;
using UnityEngine;

namespace TestGame.ViewManager
{
    public class ViewManager : IViewManager
    {
        private Dictionary<ViewDefine.ViewEnum, GameObject> m_ViewCaches = new Dictionary<ViewDefine.ViewEnum, GameObject>();
        private Dictionary<ViewDefine.Layer, IViewLayer> m_ViewLayers = new Dictionary<ViewDefine.Layer, IViewLayer>();
        private GameObject m_CanvasObject;

        public ViewManager(ViewManagerSetting setting)
        {
            var viewLayers = Object.Instantiate(setting.ViewLayerPrefab);
            Object.DontDestroyOnLoad(viewLayers.gameObject);

            m_CanvasObject = viewLayers.gameObject;
            m_CanvasObject.name = "ViewManager";

            m_ViewLayers.Add(ViewDefine.Layer.HUD, new ViewHeapLayer(viewLayers.HudPanel));
            m_ViewLayers.Add(ViewDefine.Layer.View, new ViewStackLayer(viewLayers.ViewPanel));
            m_ViewLayers.Add(ViewDefine.Layer.Top, new ViewHeapLayer(viewLayers.TopPanel));
        }

        private GameObject LoadGameObject(in ViewDefine.ViewInfo viewInfo)
        {
            // 暂时直接用Resources，后续考虑改为用ResourcesUtility
            var gameObject = Resources.Load<GameObject>(viewInfo.uiPath);
            return gameObject;
        }

        private bool GetHandleViewInfo(ViewDefine.ViewEnum viewName, out ViewDefine.ViewInfo viewInfo, out IViewLayer viewLayer)
        {
            viewLayer = null;
            if (!ViewDefine.GetViewInfo(viewName, out viewInfo))
            {
                return false;
            }
            if (!m_ViewLayers.TryGetValue(viewInfo.layer, out viewLayer))
            {
                Debug.Log("层级[" + viewInfo.layer + "]找不到对应的节点");
                return false;
            }
            return true;
        }

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
            if (IsClearing(false) || !GetHandleViewInfo(viewName, out var viewInfo, out var viewLayer))
            {
                return;
            }

            if (!m_ViewCaches.TryGetValue(viewName, out GameObject viewPrefab))
            {
                viewPrefab = LoadGameObject(in viewInfo);
                m_ViewCaches[viewName] = viewPrefab;
            }

            var viewObject = Object.Instantiate(viewPrefab);
            var view = viewObject.GetComponent<IView>();
            view.SetViewName(viewName);
            viewLayer.Push(view);
        }

        public void PopView(ViewDefine.ViewEnum viewName)
        {
            if (IsClearing(false) || !GetHandleViewInfo(viewName, out _, out var viewLayer))
            {
                return;
            }
            viewLayer.Pop(viewName);
        }

        public void PopView(IView view)
        {
            if (IsClearing(false) || !GetHandleViewInfo(view.ViewName, out _, out var viewLayer))
            {
                return;
            }
            viewLayer.Pop(view);
        }
    }
}