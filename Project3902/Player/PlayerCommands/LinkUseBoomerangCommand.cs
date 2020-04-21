
namespace Project3902
{
    class LinkUseBoomerangCommand : BaseLinkCommand
    {
        public LinkUseBoomerangCommand(FinalGame game)
            : base(game) { }

        public override void Execute()
        {
            if (game.IsPaused)
            {
                return;
            }
            if (!game.Link.CurrentWeapon.Active)
                game.Link.CurrentWeapon = WeaponFactory.Instance.CreateBoomerangProjectile();
            game.Link.UseItem();
        }
    }
}
