using Framework;

namespace TestGame.Command
{
    public class AddCountCommand : BaseCommand
    {
        protected override void OnExecute()
        {
            this.GetModel<Model.ICountModel>().Count.Value++;
        }
    }
}