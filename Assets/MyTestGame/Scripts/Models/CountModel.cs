using Framework;

namespace TestGame
{
    public class CountModel : BaseModel
    {
        public BindableProperty<int> Count = new BindableProperty<int> { Value = 0 };

        protected override void OnInitModel()
        {
        }
    }
}