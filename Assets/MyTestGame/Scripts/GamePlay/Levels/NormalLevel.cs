using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGame.Level
{
    public class NormalLevel : BaseLevel
    {
        private Component.PlayerController m_PlayerController;

        protected override void OnAwake()
        {
            m_PlayerController = GetComponent<Component.PlayerController>();
        }

        protected override void OnAddActor(IActor actor)
        {
            if (actor is Actor.IPawanActor)
            {
                OnAddPawanActor(actor as Actor.IPawanActor);
            }
        }

        protected override void OnDestroyActor(IActor actor)
        {
        }

        virtual protected void OnAddPawanActor(Actor.IPawanActor actor)
        {
            m_PlayerController.Pawan = actor;
        }
    }
}