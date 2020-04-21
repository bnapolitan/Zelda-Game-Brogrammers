﻿namespace Project3902
{
    class ChangeToRoom6Command : ICommand
    {
        private FinalGame game;

        public ChangeToRoom6Command(FinalGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.MouseSwitchRoom("DungeonRoom6");
        }
    }
}
