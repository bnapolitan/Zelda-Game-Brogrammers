using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Project3902
{
    class StartMenuState : IGameObject
    {
        private FinalGame game;
        public Vector2 Position {set;get;}
        public ISprite Sprite { set; get; }
        public bool Active { get; set; } = true;
        public List<IDrawable> ScreenElements = new List<IDrawable>();
        private HUDFactory Factory = HUDFactory.Instance;
        private SpriteAtlas titleAtlas;
        public static StartMenuState Instance { get; } = new StartMenuState();
        private StartMenuState()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IDrawable obj in ScreenElements)
            {
                obj.Draw(spriteBatch);
            }
            if (this.Active)
            {
                Sprite.Draw(spriteBatch);
            }
        }
        public void Update(GameTime gameTime)
        {
            if (this.Active)
            {
                Sprite.Update(gameTime);
            }
            
        }

        public void RegisterGame(FinalGame game)
        {
            this.game = game;

            titleAtlas = new SpriteAtlas(game.Content.Load<Texture2D>("TitleSprites"));
            List<Rectangle> titleSource = new List<Rectangle> { new Rectangle(3, 4, 256, 240), new Rectangle(262, 4, 256, 240), new Rectangle(3, 247, 256, 240), new Rectangle(262, 247, 256, 240) };

            var sprite = new AnimatedSprite(this, titleAtlas, titleSource, 0.2f, new Vector2(4,3.2f));
            this.Sprite = sprite;

        }
    }
}
