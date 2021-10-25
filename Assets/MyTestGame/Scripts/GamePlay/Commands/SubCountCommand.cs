using Framework;

namespace TestGame.Command
{
    public class SubCountCommand : BaseCommand
    {
        protected override void OnExecute()
        {
            this.GetModel<ICountModel>().Count.Value--;
        }
    }
}