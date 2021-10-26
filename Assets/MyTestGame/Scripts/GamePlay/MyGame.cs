using Framework;
using Framework.Common.System;

namespace TestGame
{
    public class MyGame : Architecture<MyGame>
    {
        protected override void Init()
        {
            RegisterModel<ICountModel>(new CountModel());

            RegisterSystem<IAchievementSystem>(new AchievementSystem());
            RegisterSystem<ITimeSystem>(new TimeSystem());

            RegisterUtility<IStogeUtility>(new StogeUtility());
        }
    }
}