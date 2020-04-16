namespace Project3902
{
    class LinkSlowDownCommand : BaseLinkCommand
    {
        public LinkSlowDownCommand(FinalGame game)
            : base(game) { }

        public override void Execute()
        {
            game.Link.MovementSpeed -= 100f;
        }
    }
}
