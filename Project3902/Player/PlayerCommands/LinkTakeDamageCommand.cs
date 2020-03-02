namespace Project3902
{
    class LinkTakeDamageCommand : ICommand
    {
        private readonly FinalGame game;

        public LinkTakeDamageCommand(FinalGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Link = new DamagedLink(game.Link, game);
        }
    }
}
