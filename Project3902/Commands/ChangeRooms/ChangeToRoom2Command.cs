namespace Project3902
{
    class ChangeToRoom2Command : ICommand
    {
        private FinalGame game;

        public ChangeToRoom2Command(FinalGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.MouseSwitchRoom("DungeonRoom2");
        }
    }
}
