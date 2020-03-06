namespace Project3902
{
    class LinkMoveRightCommand : BaseLinkCommand
    {
        public LinkMoveRightCommand(FinalGame game)
            : base(game) { }

        public override void Execute()
        {
            game.Link.MoveRight();
        }
    }
}
