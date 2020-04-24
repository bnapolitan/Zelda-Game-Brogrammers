namespace Project3902
{
    class ContinueGameCommand: ICommand
    {
        FinalGame game;
        public ContinueGameCommand(FinalGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
                game.GameStart(false);
                StartMenuState.Instance.Active = false;
                return;
        }
    }
}
