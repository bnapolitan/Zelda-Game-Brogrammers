namespace Project3902
{
    class CycleNextEnvironmentObjectCommand : ICommand
    {
        private FinalGame game;

        public CycleNextEnvironmentObjectCommand(FinalGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.CycleEnvironmentNext();
        }
    }
}
