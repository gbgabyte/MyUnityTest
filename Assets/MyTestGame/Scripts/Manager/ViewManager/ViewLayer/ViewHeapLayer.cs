using System.Collections.Generic;
using UnityEngine;

namespace TestGame.ViewManager
{
    class ViewHeapLayer : IViewLayer
    {
        private readonly Transform m_LayerParent;
        private List<IView> m_ViewList = new List<IView>();

        public ViewHeapLayer(Transform layerParent)
        {
            m_LayerParent = layerParent;
        }

        public void Clear()
        {
            foreach (var view in m_ViewList)
            {
                view.DestroyView();
            }
            m_ViewList.Clear();
        }

        public void Pop(ViewDefine.ViewEnum viewName)
        {
            var index = m_ViewList.FindLastIndex((view) => view.ViewName == viewName);
            Pop(index);
        }

        public void Pop(IView view)
        {
            var code = view.GetHashCode();
            var index = m_ViewList.FindIndex((view) => view.GetHashCode() == code);
            Pop(index);
        }

        public void Push(IView view)
        {
            view.SetParent(m_LayerParent);
            m_ViewList.Add(view);
        }

        private void Pop(int viewIndex)
        {
            if (viewIndex < 0 || viewIndex >= m_ViewList.Count)
            {
                return;
            }

            var view = m_ViewList[viewIndex];
            m_ViewList.RemoveAt(viewIndex);

            view.SetViewManager(null);
            view.DestroyView();
        }
    }
}
