namespace Project3902
{
    class LinkMoveDownCommand : BaseLinkCommand
    {
        public LinkMoveDownCommand(FinalGame game)
            : base(game) { }

        public override void Execute()
        {
            game.Link.MoveDown();
        }
    }
}
