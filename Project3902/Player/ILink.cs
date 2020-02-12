using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    interface ILink : ICharacter, ILinkActions
    {
        float MaxHealth { get; set; }

        IProjectile CurrentWeapon { get; set; }
        IProjectile SwordProjectile { get; set; }
    }
}
