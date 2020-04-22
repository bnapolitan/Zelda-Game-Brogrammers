namespace Project3902
{
    class LinkUseItemCommand : BaseLinkCommand
    {
        public LinkUseItemCommand(FinalGame game)
            : base(game) { }

        public override void Execute()
        {
            if (game.IsPaused)
            {
                return;
            }
            game.Link.UseItem();
        }
    }
}
