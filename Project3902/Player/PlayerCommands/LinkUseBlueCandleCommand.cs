using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class LinkUseBlueCandleCommand : BaseLinkCommand
    {
        public LinkUseBlueCandleCommand(Link link)
            : base(link) { }

        public override void Execute()
        {
            if (!link.CurrentWeapon.Active)
                link.CurrentWeapon = WeaponFactory.Instance.CreateBlueCandleProjectile();
            link.UseItem();
        }
    }
}
