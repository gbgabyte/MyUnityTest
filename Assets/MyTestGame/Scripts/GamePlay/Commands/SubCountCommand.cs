using Framework;

namespace TestGame
{
    public class SubCountCommand : BaseCommand
    {
        protected override void OnExecute()
        {
            this.GetModel<ICountModel>().Count.Value--;
        }
    }
}