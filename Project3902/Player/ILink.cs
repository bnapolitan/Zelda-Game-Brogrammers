﻿using Microsoft.Xna.Framework;

namespace Project3902
{
    interface ILink : ICharacter, ILinkActions
    {
        float MaxHealth { get; set; }
        bool Damaged { get; set; }
        Vector2 FacingDirection { get; set; }

        IProjectile CurrentWeapon { get; set; }
        IProjectile SwordProjectile { get; set; }
        IProjectile Sword { get; set; }

        int CoinCount { get; set; }
        int KeyCount { get; set; }
        int PotionCount { get; set; }
    }
}
