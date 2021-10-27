using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGame.Actor
{
    public interface IPawanActor : IActor
    {
        void SetMove(float x);
    }

    /// <summary>
    /// 玩家可操作对象
    /// </summary
    [RequireComponent(typeof(Rigidbody2D))]
    public class PawnActor : BaseActor, IPawanActor
    {
        public void SetMove(float x)
        {
            var velocity = new Vector2 { x = x * 10, y = 0 };
            gameObject.GetComponent<Rigidbody2D>().velocity = velocity;
        }
    }
}