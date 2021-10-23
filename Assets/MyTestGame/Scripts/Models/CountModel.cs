using Framework;

namespace TestGame
{
    public interface ICountModel : IModel
    {
        BindableProperty<int> Count { get; }
    }

    public class CountModel : BaseModel, ICountModel
    {
        public BindableProperty<int> Count { get; } = new BindableProperty<int>()
        {
            Value = 0
        };

        protected override void OnInitModel()
        {
        }
    }
}