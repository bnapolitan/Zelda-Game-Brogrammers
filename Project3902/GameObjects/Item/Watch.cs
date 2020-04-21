using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project3902.GameObjects;

namespace Project3902
{
    class Watch : IItem
    {
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        public bool Active { get; set; }
        public Collider Collider { get; set; }
        private FinalGame game;

        public Watch(Vector2 pos, FinalGame game)
        {
            Position = pos;
            Active = true;
            this.game = game;
        }
        public void TakeDamage()
        {

        }
        public void Attack()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Active)
            Sprite.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
        }

        public void OnCollide(Collider other)
        {
        }

        public void FreezeEnemies()
        {
            game.FreezeEnemies();
        }
    }
}