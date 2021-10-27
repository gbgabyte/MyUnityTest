using Framework;
using UnityEngine;

namespace TestGame.Utility
{
    public interface IResourcesUtility : IUtility
    {
        TResult Load<TResult>(in string path) where TResult : Object;
    }

    public class ResourcesUtility : AbstractUtility, IResourcesUtility
    {
        public TResult Load<TResult>(in string path) where TResult : Object
        {
            return Resources.Load<TResult>(path);
        }
    }
}
