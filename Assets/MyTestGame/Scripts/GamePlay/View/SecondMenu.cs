﻿using UnityEngine;
using UnityEngine.UI;
using Framework;

namespace TestGame
{
    public class SecondMenu : BaseView
    {
        [SerializeField]
        private Button m_CloseButton;

        [SerializeField]
        private Button m_AddButton;

        [SerializeField]
        private Button m_DownButton;

        [SerializeField]
        private Text m_TextNumber;

        private void Awake()
        {
            m_CloseButton.onClick.AddListener(PopSelf);
            m_AddButton.onClick.AddListener(() => this.SendCommand<AddCountCommand>());
            m_DownButton.onClick.AddListener(() => this.SendCommand<SubCountCommand>());


            var countModel = this.GetModel<ICountModel>();
            countModel.Count.OnValueChanged += OnNumberChange;
            OnNumberChange(countModel.Count.Value);
        }

        private void OnDestroy()
        {
            var countModel = this.GetModel<ICountModel>();
            countModel.Count.OnValueChanged -= OnNumberChange;
        }

        private void OnNumberChange(in int value)
        {
            m_TextNumber.text = value.ToString();
        }
    }
}