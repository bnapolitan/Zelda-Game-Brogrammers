﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project3902.GameObjects.EnemyProjectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class WeaponFactory : ISpriteFactory
    {
        private SpriteAtlas weaponAtlas;
        private SpriteAtlas bossSpriteAtlas;
        private Vector2 weaponScale = new Vector2(4, 4);

        private Vector2 up = new Vector2(0, -1);
        private Vector2 down = new Vector2(0, 1);
        private Vector2 left = new Vector2(-1, 0);

        public static WeaponFactory Instance { get; } = new WeaponFactory();

        private WeaponFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            weaponAtlas = new SpriteAtlas(content.Load<Texture2D>("linkspritesheet"));
            bossSpriteAtlas = new SpriteAtlas(content.Load<Texture2D>("Dungeon_Enemies_2"));
           
        }

        public IProjectile CreateBoomerangProjectile()
        {
            return new BoomerangWeapon();
        }

        public ISprite CreateBoomerangSprite(IGameObject boomerang)
        {
            List<Rectangle> sourceRects = new List<Rectangle> { new Rectangle(128, 204, 8, 8), new Rectangle(137, 204, 8, 8), 
                                                                new Rectangle(146, 204, 8, 8), new Rectangle(155, 204, 8, 8),
                                                                new Rectangle(164, 204, 8, 8), new Rectangle(173, 204, 8, 8),
                                                                new Rectangle(182, 204, 8, 8), new Rectangle(191, 204, 8, 8)};
            return new AnimatedSprite(boomerang, weaponAtlas, sourceRects, .1f, weaponScale);
        }

        public IProjectile CreateBlueCandleProjectile()
        {
            return new BlueCandleWeapon();
        }

        public ISprite CreateBlueCandleFireSprite(IGameObject fire)
        {
            return new FlippingSprite(fire, weaponAtlas, new Rectangle(191, 185, 16, 16), .1f, weaponScale);
        }

        public ISprite CreateSwordProjectileSprite(IGameObject swordProjectile, Vector2 direction)
        {
            // Default flip and source for right-facing sword.
            SpriteEffects flip = SpriteEffects.None;
            Rectangle sourceRect = new Rectangle(45, 159, 16, 7);
            Rectangle verticleRect = new Rectangle(36, 154, 7, 16);

            if (direction == left)
                flip = SpriteEffects.FlipHorizontally;
            else if (direction == up)
                sourceRect = verticleRect;
            else if (direction == down)
            {
                sourceRect = verticleRect;
                flip = SpriteEffects.FlipVertically;
            }

            var sprite = new FixedSprite(swordProjectile, weaponAtlas, sourceRect, weaponScale);
            sprite.Flip = flip;

            return sprite;
        }

        public IProjectile CreateFireballProjectile(Vector2 pos, Vector2 direction)
        {
            var createdObject = new Fireball(pos, 4f, direction);
            List<Rectangle> fireballSource = new List<Rectangle> { new Rectangle(334, 3, 8, 9) };
            var sprite = new AnimatedSprite(createdObject, bossSpriteAtlas, fireballSource, 0.5f, new Vector2(2, 2));
            createdObject.Sprite = sprite;
            return createdObject;
        }

        public IProjectile CreateBoomerangProjectile(Vector2 pos, Vector2 direction)
        {
            var createdObject = new Boomerang(pos, 300f, direction);
            List<Rectangle> boomerangSource = new List<Rectangle> { 
                new Rectangle(128, 204, 8, 8), new Rectangle(128, 204, 8, 8), new Rectangle(137, 204, 8, 8), new Rectangle(146, 204, 8, 8), 
                new Rectangle(128, 204, 8, 8), new Rectangle(155, 204, 8, 8), new Rectangle(164, 204, 8, 8), new Rectangle(173, 204, 8, 8) };
            var sprite = new AnimatedSprite(createdObject, weaponAtlas, boomerangSource, 0.1f, new Vector2(4, 4));
            createdObject.Sprite = sprite;
            return createdObject;
        }
    }
}
