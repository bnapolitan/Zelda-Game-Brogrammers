using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902.GameObjects.Enemies_and_NPCs.Interfaces
{
    class Goriya : IEnemy
    {
        public float Health { get; set; }
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        public bool Active { get; set; }
        public Rectangle hitbox { get; set; }
        private float speed;
        private float distance = 100;
        private Vector2 relPos = new Vector2(0, 0);
        private Vector2 direction;
        private SpriteEffects flip = SpriteEffects.None;
        public ISprite rightFacingGoriya;
        public ISprite leftFacingGoriya;
        public ISprite downFacingGoriya;
        public ISprite upFacingGoriya;

        public Goriya(Vector2 pos, float moveSpeed, Vector2 initDirection)
        {
            Position = pos;
            Active = true;
            speed = moveSpeed;
            direction = initDirection;
        }
        public void TakeDamage()
        {

        }
        public void Attack()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Console.WriteLine("E");
            (Sprite as AnimatedSprite).Draw(spriteBatch, flip);
        }

        public void OnCollide()
        {

        }

        public void Update(GameTime gameTime)
        {
            Console.WriteLine("A");
            Position += direction * speed;
            relPos += direction * speed;
            if (relPos.X > distance)
            {
                direction =new Vector2(0,1);
                Sprite = downFacingGoriya;
                relPos = new Vector2(0, 0);
            }
            else if (relPos.Y > distance)
            {
                direction = new Vector2(-1,0);
                Sprite = leftFacingGoriya;
                relPos = new Vector2(0, 0);
            }
            else if(relPos.X < -distance)
            {
                direction = new Vector2(0, -1);
                Sprite = upFacingGoriya;
                relPos = new Vector2(0, 0);
            }
            else if (relPos.Y < -distance)
            {
                direction = new Vector2(1, 0);
                Sprite = rightFacingGoriya;
                relPos = new Vector2(0, 0);
            }
            Sprite.Update(gameTime);
        }
    }
}