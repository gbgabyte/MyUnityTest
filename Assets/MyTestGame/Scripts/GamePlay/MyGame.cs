using Framework;
using TestGame.ViewManager;
using UnityEngine;

namespace TestGame
{
    public interface IBelongViewManager
    {
        void PushView(ViewDefine.ViewEnum viewName);

        void PopView(ViewDefine.ViewEnum viewName);

        void ClearAllView();
    }

    public class MyGame : Architecture<MyGame>, IBelongViewManager
    {
        public IViewManager ViewManager { get; set; }

        protected override void Init()
        {
            RegisterModel(new CountModel());

            RegisterSystem(new AchievementSystem());
            RegisterSystem<ITimeSystem>(new TimeSystem());

            RegisterUtility(new StogeUtility());
        }

        public void PushView(ViewDefine.ViewEnum viewName)
        {
            ViewManager?.PushView(viewName);
        }

        public void PopView(ViewDefine.ViewEnum viewName)
        {
            ViewManager?.PopView(viewName);
        }

        public void ClearAllView()
        {
            ViewManager?.ClearView();
        }
    }
}