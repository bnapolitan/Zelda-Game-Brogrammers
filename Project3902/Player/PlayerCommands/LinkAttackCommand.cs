namespace Project3902
{
    class LinkAttackCommand : BaseLinkCommand
    {
        public LinkAttackCommand(ILink link)
            : base(link) { }

        public override void Execute()
        {
            link.Attack();
        }
    }
}
