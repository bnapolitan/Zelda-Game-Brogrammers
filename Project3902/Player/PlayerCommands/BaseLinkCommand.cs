namespace Project3902
{
    abstract class BaseLinkCommand : ICommand
    {
        protected readonly FinalGame game;

        public BaseLinkCommand(FinalGame game)
        {
            this.game = game;
        }

        public abstract void Execute();
    }
}
