using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace TestGame
{
    public interface ILevelComponent
    {
        bool IsNeedUpdate { get; }

        void InitComponent();

        void SetLevelLogic(ILevelLogic level);
    }

    public abstract class BaseLevelComponent : AbstractViewController, ILevelComponent
    {
        public ILevelLogic LevelLogic { get; private set; }

        private bool m_NeedUpdate = false;
        public bool IsNeedUpdate => m_NeedUpdate;

        public abstract void InitComponent();

        void ILevelComponent.SetLevelLogic(ILevelLogic level)
        {
            LevelLogic = level;
        }
    }
}