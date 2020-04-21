namespace Project3902
{
    class ChangeToRoom8Command : ICommand
    {
        private FinalGame game;

        public ChangeToRoom8Command(FinalGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.MouseSwitchRoom("DungeonRoom8");
        }
    }
}
