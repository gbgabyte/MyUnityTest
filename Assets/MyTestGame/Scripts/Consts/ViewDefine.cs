using System.Collections.Generic;
using UnityEngine;

namespace TestGame
{
    public static class ViewDefine
    {
        public enum ViewEnum
        {
            HudView,
            MainMenu,
            SecondMenu,
        }

        public enum Layer
        {
            HUD,
            View,
            Top,
        }

        public struct ViewInfo
        {
            public readonly string uiPath;
            public readonly Layer layer;

            public ViewInfo(Layer layer, string local)
            {
                this.layer = layer;
                uiPath = local;
            }
        }

        static private readonly Dictionary<ViewEnum, ViewInfo> ViewRegisters = new Dictionary<ViewEnum, ViewInfo>()
        {
            {ViewEnum.HudView, new ViewInfo(layer: Layer.HUD, local: "View/HudView") },
            {ViewEnum.MainMenu, new ViewInfo(layer: Layer.View, local: "View/MainMenu") },
            {ViewEnum.SecondMenu, new ViewInfo(layer: Layer.View, local: "View/SecondMenu") },
        };

        static public bool GetViewInfo(ViewEnum viewName, out ViewInfo viewInfo)
        {
            if (!ViewRegisters.TryGetValue(viewName, out viewInfo))
            {
                Debug.LogWarning("界面枚举[" + viewName + "]没有注册界面");
                return false;
            }
            return true;
        }
    }
}