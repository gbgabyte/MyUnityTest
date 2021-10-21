using UnityEngine;

namespace TestGame.ViewManager
{
    public interface IView
    {
        ViewDefine.ViewEnum ViewName { get; }

        void SetViewName(ViewDefine.ViewEnum viewName);

        void SetParent(Transform parent);

        void DestroyView();
    }
}
