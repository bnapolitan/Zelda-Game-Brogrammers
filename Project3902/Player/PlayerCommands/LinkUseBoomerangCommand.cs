namespace Project3902
{
    class LinkUseBoomerangCommand : BaseLinkCommand
    {
        public LinkUseBoomerangCommand(ILink link)
            : base(link) { }

        public override void Execute()
        {
            if (!link.CurrentWeapon.Active)
                link.CurrentWeapon = WeaponFactory.Instance.CreateBoomerangProjectile();
            link.UseItem();
        }
    }
}
