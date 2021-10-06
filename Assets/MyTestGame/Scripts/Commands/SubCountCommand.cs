using Framework;

public class SubCountCommand : AbstractCommand
{
    protected override void OnExecute()
    {
        this.GetModel<CountModel>().Count.Value--;
    }
}
