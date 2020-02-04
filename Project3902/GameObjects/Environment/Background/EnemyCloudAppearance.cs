using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902.GameObjects.Environment
{
    class EnemyCloudAppearance : FixedGameObject, IBackgroundEnvironmentObject
    {

        public EnemyCloudAppearance(Vector2 position)
            : base(position) { }

    }
}
