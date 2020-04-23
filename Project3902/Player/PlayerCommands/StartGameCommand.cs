namespace Project3902
{
    class StartGameCommand: ICommand
    {
        FinalGame game;
        public StartGameCommand(FinalGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            if (game.isRunning == false)
            {
                game.GameStart();
                StartMenuState.Instance.Active = false;
                return;
            }
            if (game.IsPaused)
            {
                return;
            }
        }
    }
}
