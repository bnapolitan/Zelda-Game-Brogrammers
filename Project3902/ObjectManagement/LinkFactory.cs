using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class LinkFactory : ISpriteFactory
    {
        private SpriteAtlas linkAtlas;
        private Vector2 linkScale = new Vector2(4, 4);

        private static readonly LinkFactory instance = new LinkFactory();

        public static LinkFactory Instance => instance;

        private LinkFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            linkAtlas = new SpriteAtlas(content.Load<Texture2D>("linkspritesheet"));
        }

        public Link CreateLink(Vector2 position)
        {
            return new Link(position);
        }

        public ISprite CreateHorizontalWalkSprite(IGameObject link)
        {
            List<Rectangle> sourceRects = new List<Rectangle> { new Rectangle(35, 11, 16, 16), new Rectangle(52, 11, 16, 16) };
            return new AnimatedSprite(link, linkAtlas, sourceRects, .2f, linkScale);
        }

        public ISprite CreateUpwardsWalkSprite(IGameObject link)
        {
            List<Rectangle> sourceRects = new List<Rectangle> { new Rectangle(69, 11, 16, 16), new Rectangle(86, 11, 16, 16) };
            return new AnimatedSprite(link, linkAtlas, sourceRects, .2f, linkScale);
        }

        public ISprite CreateDownwardsWalkSprite(IGameObject link)
        {
            List<Rectangle> sourceRects = new List<Rectangle> { new Rectangle(1, 11, 16, 16), new Rectangle(18, 11, 16, 16) };
            return new AnimatedSprite(link, linkAtlas, sourceRects, .2f, linkScale);
        }

    }
}
