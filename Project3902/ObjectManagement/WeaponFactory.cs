﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project3902.GameObjects.EnemyProjectiles;
using System.Collections.Generic;

namespace Project3902
{
    class WeaponFactory : ISpriteFactory
    {
        private SpriteAtlas weaponAtlas;
        private SpriteAtlas bossSpriteAtlas;
        private SpriteAtlas itemAtlas;
        private readonly Vector2 weaponScale = new Vector2(4, 4);

        private readonly Vector2 up = new Vector2(0, -1);
        private readonly Vector2 down = new Vector2(0, 1);
        private readonly Vector2 left = new Vector2(-1, 0);

        public static WeaponFactory Instance { get; } = new WeaponFactory();

        private WeaponFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            weaponAtlas = new SpriteAtlas(content.Load<Texture2D>("linkspritesheet"));
            bossSpriteAtlas = new SpriteAtlas(content.Load<Texture2D>("Dungeon_Enemies_2"));
            itemAtlas = new SpriteAtlas(content.Load<Texture2D>("Items"));
        }

        public IProjectile CreateBoomerangProjectile(ILink link)
        {
            var boomerang = new BoomerangWeapon();
            var collider = new Collider(boomerang, new Rectangle(0, 0, 8 * (int)boomerang.Sprite.Scale.X, 8 * (int)boomerang.Sprite.Scale.Y));
            boomerang.Collider = collider;
            boomerang.Link = link;
            CollisionHandler.Instance.RegisterCollidable(boomerang, Layer.Projectile, Layer.Enemy, Layer.Wall, Layer.Player);
            return boomerang;
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
            var candle = new BlueCandleWeapon();
            var collider = new Collider(candle, new Rectangle(0, 0, 16 * (int)candle.Sprite.Scale.X, 16 * (int)candle.Sprite.Scale.Y));
            candle.Collider = collider;
            CollisionHandler.Instance.RegisterCollidable(candle, Layer.Projectile, Layer.Enemy, Layer.Wall);
            return candle;
        }

        public ISprite CreateBlueCandleFireSprite(IGameObject fire)
        {
            return new FlippingSprite(fire, weaponAtlas, new Rectangle(191, 185, 16, 16), .1f, weaponScale);
        }

        public ISprite CreateSwordProjectileSprite(IGameObject swordProjectile, Vector2 direction)
        {

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


            var sprite = new FixedSprite(swordProjectile, weaponAtlas, sourceRect, weaponScale)
            {
                Flip = flip
            };

            return sprite;
        }

        public IProjectile CreateSwordProjectile()
        {
            var sword = new SwordProjectile();

            var rect = new Rectangle(0, 0, (int)sword.Sprite.Scale.X * (int)sword.Sprite.Size.X, (int)sword.Sprite.Scale.Y * (int)sword.Sprite.Size.Y);
            var collider = new Collider(sword, rect);
            sword.Collider = collider;
            return sword;
        }

        public IProjectile CreateSwordParticle()
        {
            return new SwordParticleProjectile();
        }

        public ISprite CreateSwordParticleSprite(IGameObject particleObject, Vector2 direction)
        {
            SpriteEffects flip = SpriteEffects.None;
            Rectangle sourceRect = new Rectangle(62, 157, 8, 10);

            if (direction.X > 0)
                flip = SpriteEffects.FlipHorizontally;

            if (direction.Y > 0)
                flip |= SpriteEffects.FlipVertically;


            var sprite = new FixedSprite(particleObject, weaponAtlas, sourceRect, weaponScale)
            {
                Flip = flip
            };

            return sprite;
        }

        public IProjectile CreateSword()
        {
            return new SwordAttack();
        }

        public IProjectile CreateBomb(Vector2 position)
        {
            var createdObject = new Bomb(position);
            List<Rectangle> bombSource = new List<Rectangle> { new Rectangle(528, 0, 38, 44) };
            var sprite = new AnimatedSprite(createdObject, itemAtlas, bombSource, .4f, new Vector2(1, 1));
            createdObject.Sprite = sprite;
            createdObject.Collider = new Collider(createdObject, new Rectangle(0, 0, 80, 100));
            CollisionHandler.Instance.RegisterCollidable(createdObject, Layer.Projectile, Layer.Enemy, Layer.Wall, Layer.Player);
            return createdObject;
        }

        public IProjectile CreateFireballProjectile(Vector2 pos, Vector2 direction)
        {
            var createdObject = new Fireball(pos, 5f, direction);
            List<Rectangle> fireballSource = new List<Rectangle> { new Rectangle(364, 33, 8, 16) };
            var sprite = new AnimatedSprite(createdObject, bossSpriteAtlas, fireballSource, 0.5f, new Vector2(3.4f, 3.4f));
            createdObject.Sprite = sprite;
            var collider = new Collider(createdObject, new Rectangle(0, 0, 8 * (int)createdObject.Sprite.Scale.X, 8 * (int)createdObject.Sprite.Scale.Y));
            createdObject.Collider = collider;
            CollisionHandler.Instance.RegisterCollidable(createdObject, Layer.Projectile, Layer.Wall, Layer.Player);
            return createdObject;
        }

        public ISprite CreateFireballSprite(IGameObject fireball)
        {
            var fireballSource = new Rectangle(334, 3, 8, 9);
            var sprite = new FixedSprite(fireball, bossSpriteAtlas, fireballSource, new Vector2(2, 2));
            return sprite;
        }

        public IProjectile CreateBoomerangProjectile(Vector2 pos, Vector2 direction)
        {
            var createdObject = new Boomerang(pos, 300f, direction);
            //List<Rectangle> ArrowSource = new List<Rectangle> { new Rectangle(848, 0, 22, 61) };
            var sprite = CreateBoomerangSprite(createdObject);
            createdObject.Sprite = sprite;
            var collider = new Collider(createdObject, new Rectangle(0, 0, 8 * (int)sprite.Scale.X, 8 * (int)sprite.Scale.Y));
            createdObject.Collider = collider;
            CollisionHandler.Instance.RegisterCollidable(createdObject, Layer.Projectile, Layer.Wall, Layer.Player);
            return createdObject;
        }

        public IProjectile CreateArrowProjectile(Vector2 direction)
        {
            var arrow = new ArrowProjectile();

            SpriteEffects flip = SpriteEffects.None;
            Rectangle sourceRect = new Rectangle(10, 189, 15, 7);
            Rectangle verticleRect = new Rectangle(2, 185, 7, 15);

            if (direction == left)
                flip = SpriteEffects.FlipHorizontally;
            else if (direction == up)
                sourceRect = verticleRect;
            else if (direction == down)
            {
                sourceRect = verticleRect;
                flip = SpriteEffects.FlipVertically;
            }


            var sprite = new FixedSprite(arrow, weaponAtlas, sourceRect, weaponScale)
            {
                Flip = flip
            };
            arrow.Sprite = sprite;
            return arrow;
        }
    }
}
