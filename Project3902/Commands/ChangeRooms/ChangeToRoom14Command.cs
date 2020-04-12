namespace Project3902
{
    class ChangeToRoom14Command : ICommand
    {
        private readonly FinalGame game;

        public ChangeToRoom14Command(FinalGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.MouseSwitchRoom("DungeonRoom14");
        }
    }
}
