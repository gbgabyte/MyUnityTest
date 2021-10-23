using TestGame.ViewManager;
using UnityEngine;

namespace TestGame
{
    /// <summary>
    /// 基础界面类，需要通过ViewManager打开
    /// </summary>
    public class BaseView : AbstractViewController, IView, ICanOptView
    {
        private ViewDefine.ViewEnum m_ViewName;
        public ViewDefine.ViewEnum ViewName => m_ViewName;

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
            this.PopView(this);
        }
    }
}
