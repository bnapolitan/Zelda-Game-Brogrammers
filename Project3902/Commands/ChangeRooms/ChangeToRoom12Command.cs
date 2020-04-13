namespace Project3902
{
    class ChangeToRoom12Command : ICommand
    {
        private readonly FinalGame game;

        public ChangeToRoom12Command(FinalGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.MouseSwitchRoom("DungeonRoom12");
        }
    }
}
