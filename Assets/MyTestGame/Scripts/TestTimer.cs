using UnityEngine;
using Framework;
using TestGame.ViewManager;

namespace TestGame
{
    public class TestTimer : BaseView
    {
        private ITimer mTimer;

        void Start()
        {
            var timeSystem = this.GetSystem<ITimeSystem>();
            timeSystem.AddDelayTask(10, (deltaTime) => Debug.Log("延迟时间" + deltaTime));
            mTimer = timeSystem.AddTask(5, (deltaTime) => Debug.Log("定时时间" + deltaTime));

            this.PushView(ViewDefine.ViewEnum.HudView);
        }

        private void OnDestroy()
        {
            mTimer.KillTimer();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                mTimer.KillTimer();
            }
        }
    }
}