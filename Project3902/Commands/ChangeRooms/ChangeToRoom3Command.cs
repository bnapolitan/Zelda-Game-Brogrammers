namespace Project3902
{
    class ChangeToRoom3Command : ICommand
    {
        private readonly FinalGame game;

        public ChangeToRoom3Command(FinalGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.MouseSwitchRoom("DungeonRoom3");
        }
    }
}
