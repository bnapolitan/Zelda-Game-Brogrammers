namespace Project3902
{
    class LinkMoveLeftCommand : BaseLinkCommand
    {
        public LinkMoveLeftCommand(FinalGame game)
            : base(game) {
        }

        public override void Execute()
        {
            game.Link.MoveLeft();
        }
    }
}
