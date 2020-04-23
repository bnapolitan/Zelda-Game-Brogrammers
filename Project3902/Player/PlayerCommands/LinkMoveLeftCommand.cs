namespace Project3902
{
    class LinkMoveLeftCommand : BaseLinkCommand
    {
        public LinkMoveLeftCommand(FinalGame game)
            : base(game) {
        }

        public override void Execute()
        {
            if (game.IsPaused)
            {
                return;
            }
            game.Link.MoveLeft();
        }
    }
}
