using Framework;

namespace TestGame
{
    public abstract class BaseCommand : AbstractCommand, ICanShowView, ICanCloseView, ICanCloseAllView
    {
    }
}
