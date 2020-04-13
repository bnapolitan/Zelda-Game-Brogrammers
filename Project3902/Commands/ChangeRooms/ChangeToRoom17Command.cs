namespace Project3902
{
    class ChangeToRoom17Command : ICommand
    {
        private readonly FinalGame game;

        public ChangeToRoom17Command(FinalGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.MouseSwitchRoom("DungeonRoom17");
        }
    }
}
