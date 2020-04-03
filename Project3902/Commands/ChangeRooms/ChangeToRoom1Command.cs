﻿namespace Project3902
{
    class ChangeToRoom1Command : ICommand
    {
        private FinalGame game;

        public ChangeToRoom1Command(FinalGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.MouseSwitchRoom("DungeonRoom1");
        }
    }
}
