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

            var face = 0;

            if (Input.GetKey(KeyCode.A))
            {
                face = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                face = 1;
            }

            Debug.Log(face);
            Pawan.SetMove(face);
        }
    }
}