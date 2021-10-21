namespace TestGame.ViewManager
{
    public interface IViewManager
    {
        /// <summary>
        /// 打开界面
        /// </summary>
        /// <param name="viewName">要压入的界面Id</param>
        void PushView(ViewDefine.ViewEnum viewName);

        /// <summary>
        /// 弹出界面
        /// </summary>
        /// <param name="viewName">要弹出的界面Id</param>
        void PopView(ViewDefine.ViewEnum viewName);

        /// <summary>
        /// 移除所有界面
        /// </summary>
        void ClearView();
    }
}