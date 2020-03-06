﻿namespace Project3902
{
    class LinkTakeDamageCommand : ICommand
    {
        private readonly FinalGame game;

        public LinkTakeDamageCommand(FinalGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            if (!(game.Link is DamagedLink))
            {
                game.Link.Health -= 1;
                game.Link = new DamagedLink(game.Link, game);
            }
        }
    }
}
