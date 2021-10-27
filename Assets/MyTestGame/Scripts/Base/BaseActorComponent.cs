using UnityEngine;

namespace TestGame
{
    public interface IActorComponent
    {
        IActor GetActor();

        void SetActor(IActor actor);

        void InitComponent();
    }

    /// <summary>
    /// 基础场景对象组件
    /// </summary>
    [RequireComponent(typeof(BaseActor))]
    public abstract class BaseActorComponent : AbstractViewController, IActorComponent
    {
        private IActor m_Actor;

        public abstract void InitComponent();

        public IActor GetActor()
        {
            return m_Actor;
        }

        void IActorComponent.SetActor(IActor actor)
        {
            m_Actor = actor;
        }
    }
}