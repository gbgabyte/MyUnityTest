using Framework;
using TestGame.ViewManager;

namespace TestGame
{
    public interface ICanShowView : IBelongArchiecture
    {
    }

    static public class CanShowViewExtension
    {
        static public void PushView(this ICanShowView self, ViewDefine.ViewEnum viewName)
        {
            (self.GetArchitecture() as MyGame)?.PushView(viewName);
        }
    }
}