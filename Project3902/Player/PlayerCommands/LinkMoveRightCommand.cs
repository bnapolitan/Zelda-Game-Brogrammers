namespace Project3902
{
    class LinkMoveRightCommand : BaseLinkCommand
    {
        public LinkMoveRightCommand(ILink link)
            : base(link) { }

        public override void Execute()
        {
            link.MoveRight();
        }
    }
}
