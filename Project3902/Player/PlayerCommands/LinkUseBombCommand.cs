
using Project3902.Configuration;
using Project3902.ObjectManagement;

namespace Project3902
{
    class LinkUseBombCommand : BaseLinkCommand
    {
        public LinkUseBombCommand(FinalGame game)
            : base(game) { }

        public override void Execute()
        {
            game.Link.CurrentWeapon = WeaponFactory.Instance.CreateBomb(game.Link.Position);
            SoundHandler.Instance.PlaySoundEffect("Bomb Drop");
            game.Link.UseItem();
        }
    }
}
