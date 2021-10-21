using Framework;

namespace TestGame
{
    public class AddCountCommand : BaseCommand
    {
        protected override void OnExecute()
        {
            this.GetModel<CountModel>().Count.Value++;
        }
    }
}