namespace Project3902
{
    class ChangeToRoom11Command : ICommand
    {
        private FinalGame game;

        public ChangeToRoom11Command(FinalGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.MouseSwitchRoom("DungeonRoom11");
        }
    }
}
