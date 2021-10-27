using Framework;

namespace TestGame.Event
{
    public struct PopViewEvent
    {
        public readonly ViewDefine.ViewEnum viewName;

        public PopViewEvent(ViewDefine.ViewEnum view)
        {
            viewName = view;
        }
    }
}