using Framework;

namespace TestGame
{
    public interface ICanOptView : IBelongArchiecture
    {
    }

    static public class CanOptViewExtension
    {
        static public void PopView(this ICanOptView self, ViewDefine.ViewEnum viewName)
        {
            (self.GetArchitecture() as MyGame)?.PopView(viewName);
        }

        static public void PushView(this ICanOptView self, ViewDefine.ViewEnum viewName)
        {
            (self.GetArchitecture() as MyGame)?.PushView(viewName);
        }
    }
}
