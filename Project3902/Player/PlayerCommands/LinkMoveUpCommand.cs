namespace Project3902
{
    class LinkMoveUpCommand : BaseLinkCommand
    {

        public LinkMoveUpCommand(ILink link)
            : base(link) { }

        public override void Execute()
        {
            link.MoveUp();
        }
    }
}
