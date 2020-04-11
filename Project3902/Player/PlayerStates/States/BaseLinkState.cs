using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project3902.Configuration;
using Project3902.GameObjects;
using Project3902.GameObjects.EnemyProjectiles;
using Project3902.GameObjects.Environment;
using Project3902.GameObjects.Environment.Interfaces;
using Project3902.LevelBuilding;
using Project3902.ObjectManagement;

namespace Project3902
{
    abstract class BaseLinkState : ILinkState
    {
        protected LinkStateMachine machine;
        protected Link link;

        public ISprite Sprite { get; set; }
        public Collider Collider { get => link.Collider; set { } }

        public BaseLinkState(Link link, LinkStateMachine machine)
        {
            this.link = link;
            this.machine = machine;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public virtual void Enter()
        {

        }

        public virtual void Exit()
        {

        }

        public abstract void MoveDown();
        public abstract void MoveLeft();
        public abstract void MoveRight();
        public abstract void MoveUp();

        public void TakeDamage(float damage)
        {
            if (!link.Damaged)
            {
                link.Health -= damage;

                LinkFactory.Instance.CreateDamagedLink();
                SoundHandler.Instance.PlaySoundEffect("Link Hurt");
            }
        }

        public abstract void Attack();

        public abstract void Update(GameTime gameTime);

        public abstract void UseItem();

        public virtual void OnCollide(Collider other)
        {
            if (other.GameObject is IDoorway)
            {
                var door = other.GameObject as OpenDoor;

                if (link.Position.X < RoomSwitchingThresholdConfiguration.LeftRoomThreshold)
                {
                    door.ChangeLevel("Left");
                    
                }
                else if (link.Position.X > RoomSwitchingThresholdConfiguration.RightRoomThreshold)
                {
                    door.ChangeLevel("Right");
                    
                }
                else if (link.Position.Y < RoomSwitchingThresholdConfiguration.TopRoomThreshold)
                {
                    door.ChangeLevel("Top");
                    
                }
                else if (link.Position.Y > RoomSwitchingThresholdConfiguration.BottomRoomThreshold)
                {
                    door.ChangeLevel("Bottom");
                    
                }
            }
            else if (other.GameObject is LockDoor && link.KeyCount > 0)
            {
                link.KeyCount--;
                switch ((other.GameObject as LockDoor).DirectionType)
                {
                    case 0:
                        LevelManager.Instance.AddObjectToCurrentLevel(EnvironmentFactory.Instance.CreateOpenDoorTop(other.GameObject.Position));
                        break;
                    case 1:
                        LevelManager.Instance.AddObjectToCurrentLevel(EnvironmentFactory.Instance.CreateOpenDoorRight(other.GameObject.Position));
                        break;
                    case 2:
                        LevelManager.Instance.AddObjectToCurrentLevel(EnvironmentFactory.Instance.CreateOpenDoorBottom(other.GameObject.Position));
                        break;
                    case 3:
                        LevelManager.Instance.AddObjectToCurrentLevel(EnvironmentFactory.Instance.CreateOpenDoorLeft(other.GameObject.Position));
                        break;
                }

                CollisionHandler.Instance.RemoveCollidable(other.GameObject as ICollidable);
                LevelManager.Instance.RemoveObjectFromCurrentLevel(other.GameObject);
                other.GameObject = null;
                SoundHandler.Instance.PlaySoundEffect("Door Unlock");
            }
            else if (other.GameObject is IInteractiveEnvironmentObject)
            {
                if(other.GameObject is MoveableBlock&&(other.GameObject as MoveableBlock).MaxFrames>0&& link.FacingDirection == (other.GameObject as MoveableBlock).Direction)
                {
                    other.GameObject.Position += link.FacingDirection * 4;
                    (other.GameObject as ICollidable).Collider.AlignHitbox();
                    (other.GameObject as MoveableBlock).MaxFrames-= 4;
                }
                else
                {
                    MoveOutOfWall(other);
                }
                
                
            }
            else if (other.GameObject is IEnemy)
            {
                TakeDamage((other.GameObject as IEnemy).Damage);
            }
            else if(other.GameObject is Boomerang)
            {
                TakeDamage((other.GameObject as Boomerang).Damage);
            }
            else if (other.GameObject is Fireball)
            {
                TakeDamage((other.GameObject as Fireball).Damage);
            }
            
            else if(other.GameObject is IItem)
            {
                LevelManager.Instance.RemoveObjectFromCurrentLevel(other.GameObject);
                if (other.GameObject is Heart || other.GameObject is Key)
                {
                    SoundHandler.Instance.PlaySoundEffect("Heart");
                    if(other.GameObject is Heart)
                    {
                        link.Health++;
                        if (link.Health > link.MaxHealth)
                        {
                            link.Health = link.MaxHealth;
                        }
                    }
                    else
                    {
                        link.KeyCount++;
                    }
                }
                else if(other.GameObject is Watch)
                {
                    var watch = other.GameObject as Watch;
                    watch.FreezeEnemies();
                    SoundHandler.Instance.PlaySoundEffect("Item");
                }
                else if(other.GameObject is Rupee)
                {
                    SoundHandler.Instance.PlaySoundEffect("Rupee");
                    link.CoinCount++;
                }
                else if(other.GameObject is RupeeBonus)
                {
                    SoundHandler.Instance.PlaySoundEffect("Rupee");
                    link.CoinCount+=5;
                }
                else if (other.GameObject is Triforce)
                {
                    SoundHandler.Instance.PlaySong("Triforce");
                }
                else
                {
                    SoundHandler.Instance.PlaySoundEffect("Item");
                    if(other.GameObject is Potion)
                    {
                        link.PotionCount++;
                    }
                }
                CollisionHandler.Instance.RemoveCollidable(other.GameObject as ICollidable);
                other.GameObject.Active = false;
            }

       


     
        }

        private void MoveOutOfWall(Collider other)
        {
            var unitDirection = link.Position - link.PreviousPosition;
            unitDirection.Normalize();

            var hitboxSize = link.Collider.Hitbox.Size;
            var offset = link.Collider.Offset;

            var testRect = new Rectangle((link.PreviousPosition + offset).ToPoint(), hitboxSize);

            while (!other.Intersects(testRect))
            {
                testRect.Location += unitDirection.ToPoint();
            }

            testRect.Location -= unitDirection.ToPoint();

            link.Position = testRect.Location.ToVector2() - offset;
        }
    }
}
