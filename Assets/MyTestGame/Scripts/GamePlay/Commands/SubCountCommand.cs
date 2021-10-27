using Framework;

namespace TestGame.Command
{
    public class SubCountCommand : BaseCommand
    {
        protected override void OnExecute()
        {
            this.GetModel<Model.ICountModel>().Count.Value--;
        }
    }
}