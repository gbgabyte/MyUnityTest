namespace TestGame.ViewManager
{
    interface IViewLayer
    {
        void Push(IView view);

        void Pop(ViewDefine.ViewEnum viewName);

        void Pop(IView view);

        void Clear();
    }
}