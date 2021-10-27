using System;
using TestGame.ViewManager;
using UnityEngine;

namespace TestGame
{
    /// <summary>
    /// 基础界面类，需要通过ViewManager打开
    /// </summary>
    [DisallowMultipleComponent]
    public class BaseView : AbstractViewController, IView, ICanOptView
    {
        private ViewDefine.ViewEnum m_ViewName;
        public ViewDefine.ViewEnum ViewName => m_ViewName;

        private WeakReference<IViewManager> m_ViewManager = new WeakReference<IViewManager>(null);

        public void DestroyView()
        {
            Destroy(gameObject);
        }

        public void SetParent(Transform parent)
        {
            transform.SetParent(parent, false);
        }

        void IView.SetViewName(ViewDefine.ViewEnum viewName)
        {
            m_ViewName = viewName;
        }

        protected void PopSelf()
        {
            if (m_ViewManager.TryGetTarget(out var viewManager))
            {
                viewManager.PopView(this);
            }
        }

        void IView.SetViewManager(IViewManager viewManager)
        {
            m_ViewManager.SetTarget(viewManager);
        }
    }
}
