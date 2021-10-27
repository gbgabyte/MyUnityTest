using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace TestGame
{
    public interface IActor
    {
        void SetParent(Transform transform);

        void SetLevelLogic(ILevelLogic level);

        public void Release();
    }

    [DisallowMultipleComponent]
    public abstract class BaseActor : AbstractViewController, IActor
    {
        private WeakReference<ILevelLogic> m_LevelLogic = new WeakReference<ILevelLogic>(null);

        private void Awake()
        {
            foreach(var component in GetComponents<IActorComponent>())
            {
                component.SetActor(this);
                component.InitComponent();
            }
        }

        public T AddComponent<T>() where T : Component, IActorComponent
        {
            var component = gameObject.AddComponent<T>();
            component.SetActor(this);
            return component;
        }

        public void RemoveComponent<T>() where T : Component, IActorComponent
        {
            if (gameObject.TryGetComponent<T>(out var component))
            {
                component.SetActor(null);
                Destroy(component);
            }
        }

        public void DestroySelf()
        {
            if (m_LevelLogic.TryGetTarget(out var level))
            {
                level.DestroyActor(this);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        void IActor.SetLevelLogic(ILevelLogic level)
        {
            m_LevelLogic.SetTarget(level);
        }

        void IActor.Release()
        {
            Destroy(gameObject);
        }

        void IActor.SetParent(Transform transform)
        {
            transform.parent.SetParent(transform, false);
        }
    }
}