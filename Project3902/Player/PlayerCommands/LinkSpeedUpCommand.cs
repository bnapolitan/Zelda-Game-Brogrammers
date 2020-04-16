namespace Project3902
{
    class LinkSpeedUpCommand : BaseLinkCommand
    {
        public LinkSpeedUpCommand(FinalGame game)
            : base(game) { }

        public override void Execute()
        {
            game.Link.MovementSpeed+=100f;
        }
    }
}
