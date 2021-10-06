using Framework;

public class MyGame : Architecture<MyGame>
{
    protected override void Init()
    {
        RegisterModel(new CountModel());
        RegisterSystem(new AchievementSystem());
        RegisterUtility(new StogeUtility());
    }
}
