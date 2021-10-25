using Framework;

namespace TestGame.Command
{
    public class AddCountCommand : BaseCommand
    {
        protected override void OnExecute()
        {
            this.GetModel<ICountModel>().Count.Value++;
        }
    }
}