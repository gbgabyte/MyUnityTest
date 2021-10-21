using Framework;
using TestGame.ViewManager;
using UnityEngine;

namespace TestGame
{
    public class MyGame : Architecture<MyGame>
    {
        private IViewManager m_ViewManager;

        protected override void Init()
        {
            RegisterModel(new CountModel());

            RegisterSystem(new AchievementSystem());
            RegisterSystem<ITimeSystem>(new TimeSystem());

            RegisterUtility(new StogeUtility());

            var viewManagerSetting = Resources.Load<ViewManagerSetting>("ViewManagerSetting");
            m_ViewManager = new ViewManager.ViewManager(viewManagerSetting);
        }

        public void PushView(ViewDefine.ViewEnum viewName)
        {
            m_ViewManager.PushView(viewName);
        }

        public void PopView(ViewDefine.ViewEnum viewName)
        {
            m_ViewManager.PopView(viewName);
        }

        public void ClearAllView()
        {
            m_ViewManager.ClearView();
        }
    }
}