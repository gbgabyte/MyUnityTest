using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TestGame
{
    public class MainMenu : BaseView
    {
        [SerializeField]
        private Button m_CloseButton;

        [SerializeField]
        private Button m_SubViewButton;

        // Start is called before the first frame update
        void Start()
        {
            m_CloseButton?.onClick.AddListener(PopSelf);
            m_SubViewButton?.onClick.AddListener(OnShowSubView);
        }

        void OnShowSubView()
        {
            this.PushView(ViewDefine.ViewEnum.SecondMenu);
        }
    }
}