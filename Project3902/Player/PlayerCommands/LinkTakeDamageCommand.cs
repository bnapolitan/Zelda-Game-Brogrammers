

namespace Project3902
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
                if(game.Link.Health < 0)
                {
                    game.ReloadOnDeath();
                    game.Link.Health = game.Link.MaxHealth;
                }
                else
                {
                    game.Link = new DamagedLink(game.Link, game);
                }
                

            }
        }
    }
}
