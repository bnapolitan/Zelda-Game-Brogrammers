namespace Project3902
{
    class LinkUseBlueCandleCommand : BaseLinkCommand
    {
        public LinkUseBlueCandleCommand(FinalGame game)
            : base(game) { }

        public override void Execute()
        {
            game.Link.CurrentWeapon = WeaponFactory.Instance.CreateBlueCandleProjectile();
            game.Link.UseItem();
        }
    }
}
