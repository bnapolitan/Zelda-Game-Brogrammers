
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
            game.Link.CurrentWeapon = WeaponFactory.Instance.CreateBoomerangProjectile(game.Link);
            game.Link.UseItem();
        }
    }
}
