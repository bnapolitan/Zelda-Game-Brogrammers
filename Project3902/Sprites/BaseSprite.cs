using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project3902
{
    // BaseSprite contains the necessary components of a sprite, but defines
    // no behavior on its own (ie. in Update()).
    // It also requires child classes to decide which IAtlasSource implementation they use.
    abstract class BaseSprite : ISprite
    {
        // 'width' and 'height' represent the actual width and height the sprite will appear in pixels
        protected float width;
        protected float height;
        protected SpriteAtlas atlas;
        protected IAtlasSource source;
        protected Vector2 scale;

        public bool CenterPivot { get; set; } = true;
        public Vector2 Position { get; set; }
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

        public BaseSprite(SpriteAtlas atlas, Vector2 position, IAtlasSource source, Vector2? scale = null)
        {
            this.atlas = atlas;
            Position = position;
            this.source = source;
            Scale = scale ?? new Vector2(1, 1);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(atlas.Texture, CalculateDestRect(), source.GetSourceRectangle(), Color.White);
        }

        public abstract void Update(GameTime gameTime);

        protected Rectangle CalculateDestRect()
        {
            if (CenterPivot)
                return new Rectangle((int)(Position.X - width / 2), (int)(Position.Y - height / 2), (int)width, (int)height);
            else
                return new Rectangle((int)Position.X, (int)Position.Y, (int)width, (int)height);
        }

        protected void SetWidthHeight(int frame = 0)
        {
            Vector2 sourceSize = source.GetFrameSize(frame);
            width = Scale.X * sourceSize.X;
            height = Scale.Y * sourceSize.Y;
        }
    }
}
