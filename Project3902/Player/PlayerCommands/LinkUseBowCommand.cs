
using Project3902.ObjectManagement;

namespace Project3902
{
    class LinkUseBowCommand : BaseLinkCommand
    {
        public LinkUseBowCommand(FinalGame game)
            : base(game) { }

        public override void Execute()
        {
            if (game.IsPaused)
            {
                return;
            }
            if (game.Link.CurrentWeapon.Active)
            {
                return;
            }
            game.Link.CurrentWeapon = WeaponFactory.Instance.CreateArrowProjectile(game.Link.FacingDirection);
            game.Link.UseItem();
            SoundHandler.Instance.PlaySoundEffect("Arrow");
        }
    }
}
