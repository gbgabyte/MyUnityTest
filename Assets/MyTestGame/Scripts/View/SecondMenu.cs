using UnityEngine;
using UnityEngine.UI;

namespace TestGame
{
    public class SecondMenu : BaseView
    {
        [SerializeField]
        private Button m_CloseButton;


        // Start is called before the first frame update
        void Start()
        {
            m_CloseButton?.onClick.AddListener(CloseSelf);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}