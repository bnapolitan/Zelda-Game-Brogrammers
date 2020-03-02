namespace Project3902
{
    class LinkMoveLeftCommand : BaseLinkCommand
    {
        public LinkMoveLeftCommand(ILink link)
            : base(link) { }

        public override void Execute()
        {
            link.MoveLeft();
        }
    }
}
