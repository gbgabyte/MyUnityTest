using Framework;

namespace TestGame.Query
{
    public class CountQuery : AbstractQuery<int>
    {
        protected override int OnDo()
        {
            var countModel = this.GetModel<ICountModel>();
            return countModel.Count.Value;
        }
    }
}