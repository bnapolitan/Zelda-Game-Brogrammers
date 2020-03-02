namespace Project3902
{
    class ExitGameCommand : ICommand
    {
        private FinalGame game;

        public ExitGameCommand(FinalGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Exit();
        }
    }
}
