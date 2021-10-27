using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGame.Level.Component
{
    public class PlayerController : BaseLevelComponent
    {
        public Actor.IPawanActor Pawan { get; set; }

        public override void InitComponent()
        {
        }

        private void FixedUpdate()
        {
            if (Pawan == null)
            {
                return;
            }

            if (Input.GetKey(KeyCode.A))
            {
                Pawan.SetMove(-1);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                Pawan.SetMove(1);
            }
        }
    }
}