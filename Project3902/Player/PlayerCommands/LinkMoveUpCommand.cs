namespace Project3902
{
    class LinkMoveUpCommand : BaseLinkCommand
    {

        public LinkMoveUpCommand(FinalGame game)
            : base(game) { }

        public override void Execute()
        {
            if (game.IsPaused)
            {
                return;
            }
            game.Link.MoveUp();
        }
    }
}
