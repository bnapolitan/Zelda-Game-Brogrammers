namespace Project3902
{
    class LinkStartGameCommand : BaseLinkCommand
    {
        public LinkStartGameCommand(FinalGame game)
            : base(game) { }

        public override void Execute()
        {
            if (game.isRunning == false)
            {
                game.GameStart();
                return;
            }
            if (game.IsPaused)
            {
                return;
            }
            game.Link.Attack();
        }
    }
}
