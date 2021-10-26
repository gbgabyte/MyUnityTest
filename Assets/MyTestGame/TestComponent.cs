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
            timeSystem.AddPriorityTask(2.0f, (dt) => Debug.Log("触发1"), 2)
                .UnRegisterWhenGameObjectDestroyed(gameObject);
            timeSystem.AddPriorityTask(2.0f, (dt) => Debug.Log("触发2"), 3)
                .UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                this.PopView(ViewDefine.ViewEnum.MainMenu);
            }
        }
    }
}