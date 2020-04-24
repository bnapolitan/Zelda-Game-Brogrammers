using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902.Configuration
{
    public static class GeneralGameConfiguration
    {
        public static int EnemyFreezeTime { get; } = 300;
        public static int ScreenScrollSpeed { get; } = 8;
        public static int BombExplodeTime { get; } = 120;
        public static float TriforceStateTimer { get; } = 9.8f;
        public static Vector2 BlackBarsLeftPosition { get; } = new Vector2(-2300, 0);
        public static Vector2 BlackBarsRightPosition { get; } = new Vector2(2550, 0);
    }
}
