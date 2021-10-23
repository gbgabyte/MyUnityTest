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
            RegisterModel<ICountModel>(new CountModel());

            RegisterSystem<IAchievementSystem>(new AchievementSystem());
            RegisterSystem<ITimeSystem>(new TimeSystem());

            RegisterUtility<IStogeUtility>(new StogeUtility());

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

        public void PopView(IView view)
        {
            m_ViewManager.PopView(view);
        }

        public void ClearAllView()
        {
            m_ViewManager.ClearView();
        }
    }
}