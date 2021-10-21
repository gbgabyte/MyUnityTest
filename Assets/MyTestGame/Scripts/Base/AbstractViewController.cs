using Framework;
using UnityEngine;

namespace TestGame
{
    public abstract class AbstractViewController : MonoBehaviour, IController
    {
        IArchitecture IBelongArchiecture.GetArchitecture()
        {
            return MyGame.Instance;
        }
    }
}