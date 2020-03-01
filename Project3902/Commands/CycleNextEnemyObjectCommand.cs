namespace Project3902.Commands.Sprint2Commands
{
    class CycleNextEnemyObjectCommand: ICommand
    {
        private FinalGame game;

        public CycleNextEnemyObjectCommand(FinalGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.CycleEnemyNext();
        }
    }
}
