namespace Project3902
{
    class ChangeToRoom10Command : ICommand
    {
        private FinalGame game;

        public ChangeToRoom10Command(FinalGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.MouseSwitchRoom("DungeonRoom10");
        }
    }
}
