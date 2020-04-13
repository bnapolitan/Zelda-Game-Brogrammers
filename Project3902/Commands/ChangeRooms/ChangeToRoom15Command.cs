namespace Project3902
{
    class ChangeToRoom15Command : ICommand
    {
        private readonly FinalGame game;

        public ChangeToRoom15Command(FinalGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.MouseSwitchRoom("DungeonRoom15");
        }
    }
}
