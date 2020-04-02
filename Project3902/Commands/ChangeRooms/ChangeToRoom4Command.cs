﻿namespace Project3902
{
    class ChangeToRoom4Command : ICommand
    {
        private FinalGame game;

        public ChangeToRoom4Command(FinalGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.MouseSwitchRoom("DungeonRoom4");
        }
    }
}
