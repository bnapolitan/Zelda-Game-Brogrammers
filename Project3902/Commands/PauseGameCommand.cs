namespace Project3902
{
    class PauseGameCommand : ICommand
    {
        private readonly FinalGame game;
        public PauseGameCommand(FinalGame game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.PauseGame();
        }
    }
}
