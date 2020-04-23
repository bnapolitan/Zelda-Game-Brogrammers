namespace Project3902
{
    class TotalPauseGameCommand : ICommand
    {
        private readonly FinalGame game;
        public TotalPauseGameCommand(FinalGame game)
        {
            this.game = game;
        }
        public void Execute()
        {
            if (game.isRunning)
            {

                game.TotalPauseGame();
            }
        }
    }
}
