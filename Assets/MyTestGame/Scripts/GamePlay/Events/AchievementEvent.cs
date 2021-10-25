using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework;

namespace TestGame.Event
{
    public struct AchievementEvent
    {
        public readonly int value;

        public AchievementEvent(int v)
        {
            value = v;
        }
    }
}