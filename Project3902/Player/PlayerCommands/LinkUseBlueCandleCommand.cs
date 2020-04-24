namespace Project3902
{
    class LinkUseBlueCandleCommand : BaseLinkCommand
    {
        public LinkUseBlueCandleCommand(FinalGame game)
            : base(game) { }

        public override void Execute()
        {
            if (game.IsPaused)
            {
                return;
            }
            if (game.Link.CurrentWeapon is BoomerangWeapon)
            {
                if (game.Link.CurrentWeapon.Active)
                {
                    return;
                }
            }
            game.Link.CurrentWeapon = WeaponFactory.Instance.CreateBlueCandleProjectile();
            game.Link.UseItem();
        }
    }
}
