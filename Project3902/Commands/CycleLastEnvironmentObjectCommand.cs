namespace Project3902
{
    class CycleLastEnvironmentObjectCommand : ICommand
    {
        private FinalGame game;

        public CycleLastEnvironmentObjectCommand(FinalGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.CycleEnvironmentLast();
        }
    }
}
