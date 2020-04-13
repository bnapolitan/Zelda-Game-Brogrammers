namespace Project3902
{
    class ChangeToRoom16Command : ICommand
    {
        private readonly FinalGame game;

        public ChangeToRoom16Command(FinalGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.MouseSwitchRoom("DungeonRoom16");
        }
    }
}
