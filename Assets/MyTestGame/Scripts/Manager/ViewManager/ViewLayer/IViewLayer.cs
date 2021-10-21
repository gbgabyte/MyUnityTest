using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGame.ViewManager
{
    interface IViewLayer
    {
        void Push(IView view);

        void Pop(ViewDefine.ViewEnum viewName);

        void Clear();
    }
}