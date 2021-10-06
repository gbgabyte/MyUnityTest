using Framework;

public class CountModel : AbstractModel
{
    public BindableProperty<int> Count = new BindableProperty<int> { Value = 0 };

    protected override void OnInitModel()
    {
    }
}
