using System.Collections.Generic;
using UnityEngine;

namespace TestGame.ViewManager
{
    class ViewStackLayer : IViewLayer
    {
        private readonly Transform m_LayerParent;
        private List<IView> m_ViewList = new List<IView>();

        public ViewStackLayer(Transform layerParent)
        {
            m_LayerParent = layerParent;
        }

        public void Clear()
        {
            foreach(var view in m_ViewList)
            {
                view.DestroyView();
            }
            m_ViewList.Clear();
        }

        public void Pop(ViewDefine.ViewEnum viewName)
        {
            var viewIndex = m_ViewList.FindLastIndex((view) => view.ViewName == viewName);
            Pop(viewIndex);
        }

        public void Pop(IView view)
        {
            var code = view.GetHashCode();
            var viewIndex = m_ViewList.FindIndex((view) => view.GetHashCode() == code);
            Pop(viewIndex);
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

            for (var index = m_ViewList.Count - 1; index >= viewIndex; --index)
            {
                var view = m_ViewList[index];
                m_ViewList.RemoveAt(index);
                view.DestroyView();
            }
        }
    }
}
