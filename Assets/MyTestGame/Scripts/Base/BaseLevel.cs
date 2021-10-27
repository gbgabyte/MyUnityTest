using UnityEngine;
using Framework;
using Framework.Common.System;
using System.Collections.Generic;

namespace TestGame
{
    public interface ILevelLogic
    {
        void Pause(string key);

        void Resume(string key);

        void DestroyActor(IActor actor);
    }

    [DisallowMultipleComponent]
    public abstract class BaseLevel : AbstractViewController, ILevelLogic
    {
        private void Awake()
        {
            foreach(var component in gameObject.GetComponents<ILevelComponent>())
            {
                component.SetLevelLogic(this);
                component.InitComponent();
            }
            OnAwake();

            foreach (var actor in FindObjectsOfType<BaseActor>())
            {
                (actor as IActor).SetLevelLogic(this);
                OnAddActor(actor);
            }
        }

        protected abstract void OnAwake();

        private HashSet<string> m_PauseSet = new HashSet<string>();
        public bool IsPause { get => m_PauseSet.Count >= 0; }

        public void Pause(string key)
        {
            m_PauseSet.Add(key);
        }

        public void Resume(string key)
        {
            m_PauseSet.Remove(key);
        }

        protected void AddActor(IActor actor)
        {
            actor.SetParent(transform);
            actor.SetLevelLogic(this);
            OnAddActor(actor);
        }

        protected abstract void OnAddActor(IActor actor);

        public void DestroyActor(IActor actor)
        {
            OnDestroyActor(actor);
            actor.Release();
        }

        protected abstract void OnDestroyActor(IActor actor);

        protected T AddComponent<T>() where T : Component, ILevelComponent
        {
            var component = gameObject.AddComponent<T>();
            return component;
        }

        protected void RemoveComponent<T>() where T : Component, ILevelComponent
        {
            if (gameObject.TryGetComponent<T>(out var component))
            {
                Destroy(component);
            }
        }
    }
}