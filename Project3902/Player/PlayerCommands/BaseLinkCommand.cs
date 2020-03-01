namespace Project3902
{
    abstract class BaseLinkCommand : ICommand
    {
        protected readonly ILink link;

        public BaseLinkCommand(ILink link)
        {
            this.link = link;
        }

        public abstract void Execute();
    }
}
