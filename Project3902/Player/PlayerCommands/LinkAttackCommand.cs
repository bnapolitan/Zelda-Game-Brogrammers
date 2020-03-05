namespace Project3902
{
    class LinkAttackCommand : BaseLinkCommand
    {
        public LinkAttackCommand(FinalGame game)
            : base(game) { }

        public override void Execute()
        {
            game.Link.Attack();
        }
    }
}
