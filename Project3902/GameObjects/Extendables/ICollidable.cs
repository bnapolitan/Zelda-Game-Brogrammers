using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    interface ICollidable
    {
        Collider Collider { get; set; }

        void OnCollide(Collider other);
    }
}
