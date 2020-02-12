using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class LinkUseBoomerangCommand : BaseLinkCommand
    {
        public LinkUseBoomerangCommand(Link link)
            : base(link) { }

        public override void Execute()
        {
            //if (!(link.CurrentWeapon is BoomerangWeapon))
            if (!link.CurrentWeapon.Active)
                link.CurrentWeapon = WeaponFactory.Instance.CreateBoomerangProjectile();
            link.UseItem();
        }
    }
}
