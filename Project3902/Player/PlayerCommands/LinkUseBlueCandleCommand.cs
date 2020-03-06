namespace Project3902
{
    class LinkUseBlueCandleCommand : BaseLinkCommand
    {
        public LinkUseBlueCandleCommand(FinalGame game)
            : base(game) { }

        public override void Execute()
        {
            if (!game.Link.CurrentWeapon.Active)
                game.Link.CurrentWeapon = WeaponFactory.Instance.CreateBlueCandleProjectile();
            game.Link.UseItem();
        }
    }
}
