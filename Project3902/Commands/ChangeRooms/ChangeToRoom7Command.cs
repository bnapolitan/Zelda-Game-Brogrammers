﻿namespace Project3902
{
    class ChangeToRoom7Command : ICommand
    {
        private readonly FinalGame game;

        public ChangeToRoom7Command(FinalGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.MouseSwitchRoom("DungeonRoom7");
        }
    }
}
