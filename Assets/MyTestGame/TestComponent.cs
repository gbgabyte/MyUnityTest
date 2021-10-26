using UnityEngine;
using Framework;
using Framework.Common.System;

namespace TestGame
{
    public class TestComponent : BaseWidget
    {
        private void Start()
        {
            this.PushView(ViewDefine.ViewEnum.HudView);

            var timeSystem = this.GetSystem<ITimeSystem>();
            timeSystem.AddPriorityTask(0.0f, (dt) => Debug.Log("触发1" + dt.ToString()), 2)
                .KillTimerWhenGameObjectDestroyed(gameObject);
            timeSystem.AddPriorityTask(0.0f, (dt) => Debug.Log("触发2" + dt.ToString()), 3)
                .KillTimerWhenGameObjectDestroyed(gameObject);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                this.PopView(ViewDefine.ViewEnum.MainMenu);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Destroy(gameObject);
            }
        }
    }
}