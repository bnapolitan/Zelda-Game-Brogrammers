namespace Project3902
{
    class LinkUseBlueCandleCommand : BaseLinkCommand
    {
        public LinkUseBlueCandleCommand(ILink link)
            : base(link) { }

        public override void Execute()
        {
            if (!link.CurrentWeapon.Active)
                link.CurrentWeapon = WeaponFactory.Instance.CreateBlueCandleProjectile();
            link.UseItem();
        }
    }
}
