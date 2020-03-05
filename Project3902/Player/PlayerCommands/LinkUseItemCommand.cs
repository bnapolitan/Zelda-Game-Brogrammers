namespace Project3902
{
    class LinkUseItemCommand : BaseLinkCommand
    {
        public LinkUseItemCommand(FinalGame game)
            : base(game) { }

        public override void Execute()
        {
            game.Link.UseItem();
        }
    }
}
