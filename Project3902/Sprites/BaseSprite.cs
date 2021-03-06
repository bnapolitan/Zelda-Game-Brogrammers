﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project3902
{
    abstract class BaseSprite : ISprite
    {
        protected float width;
        protected float height;

        protected SpriteAtlas atlas;
        protected IAtlasSource source;
        protected Vector2 scale;
        protected int currentFrame = 0;

        public IGameObject GameObject { get; set; }

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

        public Vector2 Size { get; set; }
        

        public SpriteEffects Flip { get; set; } = SpriteEffects.None;

        public BaseSprite(IGameObject gameObject, SpriteAtlas atlas, IAtlasSource source, Vector2? scale = null)
        {
            GameObject = gameObject;
            this.atlas = atlas;
            this.source = source;
            this.Size = source.GetFrameSize(0);
            Scale = scale ?? new Vector2(1, 1);
        }

        public abstract void Update(GameTime gameTime);

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(atlas.Texture, CalculateDestRect(), source.GetSourceRectangle(currentFrame), Color.White, 0, Vector2.Zero, Flip, 0f);
        }

        public virtual void DrawTinted(SpriteBatch spriteBatch, Color tint)
        {
            spriteBatch.Draw(atlas.Texture, CalculateDestRect(), source.GetSourceRectangle(currentFrame), tint, 0, Vector2.Zero, Flip, 0f);
        }

        protected Rectangle CalculateDestRect()
        {
            return new Rectangle((int)GameObject.Position.X, (int)GameObject.Position.Y, (int)width, (int)height);
        }

        protected void SetWidthHeight()
        {
            Vector2 sourceSize = source.GetFrameSize(currentFrame);
            width = Scale.X * sourceSize.X;
            height = Scale.Y * sourceSize.Y;
        }
    }
}
