namespace Project3902
{
    class ChangeToRoom13Command : ICommand
    {
        private readonly FinalGame game;

        public ChangeToRoom13Command(FinalGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.MouseSwitchRoom("DungeonRoom13");
        }
    }
}
