
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
            
            if (game.Link.CurrentWeapon.Active)
            {
                return;
            }
            if (game.Link.BombCount > 0 && game.Link.BombExplodeTime < 0)
            {
                game.Link.BombExplodeTime = GeneralGameConfiguration.BombExplodeTime;
                
                game.Link.CurrentWeapon = WeaponFactory.Instance.CreateBomb(game.Link.Position);
                SoundHandler.Instance.PlaySoundEffect("Bomb Drop");
                game.Link.UseItem();
                game.Link.BombCount--;
            }
        }
    }
}
