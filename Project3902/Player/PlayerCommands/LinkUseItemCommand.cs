namespace Project3902
{
    class LinkUseItemCommand : BaseLinkCommand
    {
        public LinkUseItemCommand(ILink link)
            : base(link) { }

        public override void Execute()
        {
            link.UseItem();
        }
    }
}
