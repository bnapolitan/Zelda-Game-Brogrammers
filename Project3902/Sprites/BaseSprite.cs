using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project3902
{
    // BaseSprite contains the necessary components of a sprite, but defines
    // no behavior on its own (ie. in Update()).
    // Keeps its position in line with a supplied IGameObject.
    // It also requires child classes to decide which IAtlasSource implementation they use.
    abstract class BaseSprite : ISprite
    {
        // 'width' and 'height' represent the actual width and height the sprite will appear in pixels
        protected float width;
        protected float height;
        protected SpriteAtlas atlas;
        protected IAtlasSource source;
        protected Vector2 scale;
        protected IGameObject gameObject;


        public Vector2 Scale
        {
            get
            {
                return scale;
            }
            set
            {
                scale = value;
                SetWidthHeight();
            }
        }
        public Texture2D Texture
        {
            get
            {
                return atlas.Texture;
            }
            set
            {
                atlas.Texture = value;
            }
        }

        public IGameObject GameObject
        {
            get
            {
                return gameObject;
            }
            set
            {
                gameObject = value;
            }
        }

        public BaseSprite(SpriteAtlas atlas, IAtlasSource source, Vector2? scale = null)
        {
            this.atlas = atlas;
            this.source = source;
            Scale = scale ?? new Vector2(1, 1);
        }

        public abstract void Update(GameTime gameTime);

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, CalculateDestRect(), source.GetSourceRectangle(), Color.White);
        }

        protected Rectangle CalculateDestRect()
        {
            return new Rectangle((int)gameObject.Position.X, (int)gameObject.Position.Y, (int)width, (int)height);
        }

        protected void SetWidthHeight(int frame = 0)
        {
            Vector2 sourceSize = source.GetFrameSize(frame);
            width = Scale.X * sourceSize.X;
            height = Scale.Y * sourceSize.Y;
        }
    }
}
