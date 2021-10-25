using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGame
{
    public class TestComponent : BaseWidget
    {
        private void Start()
        {
            this.PushView(ViewDefine.ViewEnum.HudView);
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