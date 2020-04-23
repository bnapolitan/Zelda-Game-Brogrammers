﻿namespace Project3902
{
    class LinkAttackCommand : BaseLinkCommand
    {
        public LinkAttackCommand(FinalGame game)
            : base(game) { }

        public override void Execute()
        {
            
            if (game.IsPaused)
            {
                return;
            }
            game.Link.Attack();
        }
    }
}
