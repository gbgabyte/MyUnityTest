namespace TestGame
{
    public class TestComponent : BaseWidget
    {

        void Start()
        {
            this.PushView(ViewDefine.ViewEnum.HudView);
        }

        void Update()
        {

        }
    }
}