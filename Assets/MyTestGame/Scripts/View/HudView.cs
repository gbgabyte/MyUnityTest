using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGame
{
    public class HudView : BaseView
    {
        public void OnShowMainMenu()
        {
            this.PushView(ViewDefine.ViewEnum.MainMenu);
        }
    }
}