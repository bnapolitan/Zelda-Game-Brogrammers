namespace Project3902
{
    class LinkMoveRightCommand : BaseLinkCommand
    {
        public LinkMoveRightCommand(FinalGame game)
            : base(game) { }

        public override void Execute()
        {
            if (game.IsPaused)
            {
                return;
            }
            game.Link.MoveRight();
        }
    }
}
