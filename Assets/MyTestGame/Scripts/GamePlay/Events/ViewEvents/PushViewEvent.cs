using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame.Event
{
    public struct PushViewEvent
    {
        public readonly ViewDefine.ViewEnum viewName;

        public PushViewEvent(ViewDefine.ViewEnum view)
        {
            viewName = view;
        }
    }
}
