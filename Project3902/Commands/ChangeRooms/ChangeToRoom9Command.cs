namespace Project3902
{
    class ChangeToRoom9Command : ICommand
    {
        private FinalGame game;

        public ChangeToRoom9Command(FinalGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.MouseSwitchRoom("DungeonRoom9");
        }
    }
}
