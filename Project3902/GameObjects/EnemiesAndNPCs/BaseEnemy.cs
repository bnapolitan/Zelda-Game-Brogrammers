using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project3902.GameObjects;
using Project3902.GameObjects.EnemyProjectiles;
using Project3902.LevelBuilding;
using Project3902.ObjectManagement;
using System;

namespace Project3902
{
    abstract class BaseEnemy : IEnemy
    {
        public float Health { get; set; }
        public Vector2 Direction { get; set; }
        public float MoveSpeed { get; set; }
        public float MoveSpeedBackup { get; set; }
        private Color tint = Color.White;
        public Vector2 PreviousPosition { get; set; }
        private Vector2 position;
        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                PreviousPosition = position;
                position = value;
                if (Collider != null)
                    Collider.AlignHitbox();
            }
        }
        public ISprite Sprite { get; set; }
        public bool Active { get; set; }
        public Collider Collider { get; set; }
        public float Damage { get; set; } = 1f;
        private int collisionDelay=20;
        protected bool attackedRecent = false;
        public abstract void Attack();

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (Active)
            {
                Collider.Draw(spriteBatch);
                (Sprite as AnimatedSprite).DrawTinted(spriteBatch, tint);
            }
        }

        public virtual void OnCollide(Collider other)
        {
            if (!attackedRecent)
            {
                if ((other.GameObject is IProjectile) && !(other.GameObject is Boomerang) && !(other.GameObject is Fireball))
                {
                    attackedRecent = true;
                    Health--;
                    tint = Color.Red;
                    Console.WriteLine(Health);
                    if (Health == 0)
                    {
                        Active = false;
                        SoundHandler.Instance.PlaySoundEffect("Enemy Die");
                        if (this is Zol)
                        {
                            Gel gel1 = (EnemyFactory.Instance.CreateAquaGel(Position) as Gel);
                            Gel gel2 = (EnemyFactory.Instance.CreateAquaGel(Position) as Gel);
                            gel1.Direction = new Vector2(1, 0);
                            gel2.Direction = new Vector2(-1, 0);
                            LevelManager.Instance.AddObjectToCurrentLevel(gel1);
                            LevelManager.Instance.AddObjectToCurrentLevel(gel2);
                        }
                        else
                        {
                            Random rnum = new Random();
                            int chance = rnum.Next(5);
                            if (chance == 0)
                            {
                                SoundHandler.Instance.PlaySoundEffect("Rupee");
                                int bonusChance = rnum.Next(3);
                                if (bonusChance == 0)
                                {
                                    LevelManager.Instance.AddObjectToCurrentLevel(ItemFactory.Instance.CreateRupee(Position));
                                }
                                else
                                {
                                    LevelManager.Instance.AddObjectToCurrentLevel(ItemFactory.Instance.Create1Rupee(Position));
                                }
                            }
                            if (chance == 1)
                            {
                                SoundHandler.Instance.PlaySoundEffect("Heart");
                                LevelManager.Instance.AddObjectToCurrentLevel(ItemFactory.Instance.CreateHeart(Position));
                            }
                        }
                        
                        CollisionHandler.Instance.RemoveCollidable(this);
                        LevelManager.Instance.RemoveObjectFromCurrentLevel(this);
                    }
                    else
                    {
                        SoundHandler.Instance.PlaySoundEffect("Enemy Hit");
                    }
                    Vector2 move = (other.GameObject as IProjectile).Direction * 20;
                    (other.GameObject as IProjectile).OnCollide(Collider);
                    Position = new Vector2(Position.X + move.X, Position.Y + move.Y);
                    Collider.AlignHitbox();
                }
            }
            if(other.GameObject is IInteractiveEnvironmentObject)
            {
                MoveOutOfWall(other);
                Direction=new Vector2(Direction.Y, Direction.X*-1);
            }
        }

        public abstract void TakeDamage();

        public virtual void Update(GameTime gameTime)
        {
            if (Active)
            {
                Sprite.Update(gameTime);
                if (attackedRecent)
                {
                    collisionDelay--;
                    if (collisionDelay == 0)
                    {
                        attackedRecent = false;
                        collisionDelay = 20;
                        tint = Color.White;
                    }
                }
            }
        }

        public void Freeze()
        {
            if (this.MoveSpeed != 0)
            {
                this.MoveSpeedBackup = this.MoveSpeed;
            }
            this.MoveSpeed = 0;
        }

        public void UnFreeze()
        {
            this.MoveSpeed = this.MoveSpeedBackup;
        }

        private void MoveOutOfWall(Collider other)
        {
            var unitDirection = Position - PreviousPosition;
            unitDirection.Normalize();

            var hitboxSize = Collider.Hitbox.Size;
            var offset = Collider.Offset;

            var testRect = new Rectangle((PreviousPosition + offset).ToPoint(), hitboxSize);

            while (!other.Intersects(testRect))
            {
                testRect.Location += unitDirection.ToPoint();
            }

            testRect.Location -= unitDirection.ToPoint();

            Position = testRect.Location.ToVector2() - offset;
        }
    }
}
