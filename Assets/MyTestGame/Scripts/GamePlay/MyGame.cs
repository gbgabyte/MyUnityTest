using Framework;
using Framework.Common.System;

namespace TestGame
{
    public class MyGame : Architecture<MyGame>
    {
        protected override void Init()
        {
            RegisterModel<Model.ICountModel>(new Model.CountModel());

            RegisterSystem<System.IAchievementSystem>(new System.AchievementSystem());
            RegisterSystem<ITimeSystem>(new TimeSystem());

            RegisterUtility<Utility.IStogeUtility>(new Utility.StogeUtility());
            RegisterUtility<Utility.IResourcesUtility>(new Utility.ResourcesUtility());
        }
    }
}