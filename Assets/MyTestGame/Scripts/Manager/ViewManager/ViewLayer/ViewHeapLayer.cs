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
            if (index < 0)
            {
                return;
            }

            var view = m_ViewList[index];
            m_ViewList.RemoveAt(index);
            view.DestroyView();
        }

        public void Push(IView view)
        {
            view.SetParent(m_LayerParent);
            m_ViewList.Add(view);
        }
    }
}
