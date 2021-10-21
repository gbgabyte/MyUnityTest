namespace TestGame.ViewManager
{
    interface IViewLayer
    {
        void Push(IView view);

        void Pop(ViewDefine.ViewEnum viewName);

        void Clear();
    }
}