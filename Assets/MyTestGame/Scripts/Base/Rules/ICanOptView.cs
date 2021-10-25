using Framework;
using TestGame.ViewManager;

namespace TestGame
{
    public interface ICanOptView : IBelongArchiecture
    {
    }

    static public class CanOptViewExtension
    {
        static public void PopView(this ICanOptView self, ViewDefine.ViewEnum viewName)
        {
            self.GetArchitecture().SendEvent(new Event.PopViewEvent(view: viewName));
        }

        static public void PushView(this ICanOptView self, ViewDefine.ViewEnum viewName)
        {
            self.GetArchitecture().SendEvent(new Event.PushViewEvent(view:viewName));
        }
    }
}
