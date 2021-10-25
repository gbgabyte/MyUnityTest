using Framework;

namespace TestGame
{
    public interface ICanCloseAllView : IBelongArchiecture
    {
    }

    public static class CanCloseAllViewExtension
    {
        static public void ClearAllView(this ICanCloseAllView self)
        {
            self.GetArchitecture().SendEvent<Event.CloseAllViewEvent>();
        }
    }
}
