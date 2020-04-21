namespace Project3902
{
    class ChangeToRoom5Command : ICommand
    {
        private FinalGame game;

        public ChangeToRoom5Command(FinalGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.MouseSwitchRoom("DungeonRoom5");
        }
    }
}
