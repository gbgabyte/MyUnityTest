using Framework;

public class AddCountCommand : AbstractCommand
{
    protected override void OnExecute()
    {
        this.GetModel<CountModel>().Count.Value++;
    }
}
