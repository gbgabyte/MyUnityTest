using Framework;

namespace TestGame
{
    public interface ICanCloseView : IBelongArchiecture
    {
    }

    static public class CanCloseViewExtension
    { 
        static public void PopView(this ICanCloseView self, ViewManager.ViewDefine.ViewEnum viewName)
        {
            (self.GetArchitecture() as MyGame)?.PopView(viewName);
        }
    }
}
