namespace Project3902
{
    class LinkMoveDownCommand : BaseLinkCommand
    {
        public LinkMoveDownCommand(ILink link)
            : base(link) { }

        public override void Execute()
        {
            link.MoveDown();
        }
    }
}
