using UnityEngine;
using Framework;

namespace TestGame.System
{
    public interface IAchievementSystem : ISystem
    {
        
    }

    public class AchievementSystem : BaseSystem, IAchievementSystem
    {
        private int preValue = 0;

        protected override void OnInitSystem()
        {
            var countModel = this.GetModel<Model.ICountModel>();
            preValue = countModel.Count.Value;
            countModel.Count.OnValueChanged += OnChangeCount;
        }

        private void OnChangeCount(in int value)
        {
            if (value == preValue)
            {
                return;
            }

            var stogeUtility = this.GetUtility<Utility.IStogeUtility>();

            if (value == 10 /*&& !stogeUtility.GetValue("ACHIEVEMENT_10", false)*/)
            {
                Debug.Log("触发成就10");
                this.SendEvent(new Event.AchievementEvent(v: 10));
                //stogeUtility.SaveValue("ACHIEVEMENT_10", true);
            }
            else if (value == 20 /*&& !stogeUtility.GetValue("ACHIEVEMENT_20", false)*/)
            {
                Debug.Log("触发成就20");
                this.SendEvent(new Event.AchievementEvent(v: 20));
                //stogeUtility.SaveValue("ACHIEVEMENT_20", true);
            }
            preValue = value;
        }
    }
}