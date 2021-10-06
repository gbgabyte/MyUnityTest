using Framework;
using UnityEngine;

public class BaseViewController : MonoBehaviour, IController
{
    IArchitecture IBelongArchiecture.GetArchitecture()
    {
        return MyGame.Instance;
    }
}
