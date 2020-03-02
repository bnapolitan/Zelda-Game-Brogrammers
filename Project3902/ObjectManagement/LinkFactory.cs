using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Project3902
{
    class LinkFactory : ISpriteFactory
    {
        private SpriteAtlas linkAtlas;
        private Vector2 linkScale = new Vector2(3.5f, 3.5f);
        private readonly float attackFrameTime = .15f;
        private LinkTakeDamageCommand takeDamageCommand;

        public static LinkFactory Instance { get; } = new LinkFactory();

        private LinkFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            linkAtlas = new SpriteAtlas(content.Load<Texture2D>("linkspritesheet"));
        }

        public Link CreateLink(Vector2 position, FinalGame game)
        {
            takeDamageCommand = new LinkTakeDamageCommand(game);
            return new Link(position);
        }

        public KeyboardController CreateLinkController(ILink link)
        {
            var controller = new KeyboardController();

            // Movement
            controller.RegisterCommand(Keys.Up, new LinkMoveUpCommand(link));
            controller.RegisterCommand(Keys.Down, new LinkMoveDownCommand(link));
            controller.RegisterCommand(Keys.Left, new LinkMoveLeftCommand(link));
            controller.RegisterCommand(Keys.Right, new LinkMoveRightCommand(link));
            controller.RegisterCommand(Keys.W, new LinkMoveUpCommand(link));
            controller.RegisterCommand(Keys.S, new LinkMoveDownCommand(link));
            controller.RegisterCommand(Keys.A, new LinkMoveLeftCommand(link));
            controller.RegisterCommand(Keys.D, new LinkMoveRightCommand(link));

            controller.RegisterCommand(Keys.Z, new LinkAttackCommand(link), InputState.Pressed);
            controller.RegisterCommand(Keys.N, new LinkAttackCommand(link), InputState.Pressed);

            controller.RegisterCommand(Keys.D1, new LinkUseBoomerangCommand(link), InputState.Pressed);
            controller.RegisterCommand(Keys.D2, new LinkUseBlueCandleCommand(link), InputState.Pressed);

            controller.RegisterCommand(Keys.E, takeDamageCommand, InputState.Pressed);

            return controller;
        }

        /* Walk sprites. */
        public ISprite CreateRightWalkSprite(IGameObject link)
        {
            List<Rectangle> sourceRects = new List<Rectangle> { new Rectangle(35, 11, 16, 16), new Rectangle(52, 11, 16, 16) };
            return new AnimatedSprite(link, linkAtlas, sourceRects, .2f, linkScale);
        }

        public ISprite CreateLeftWalkSprite(IGameObject link)
        {
            List<Rectangle> sourceRects = new List<Rectangle> { new Rectangle(35, 11, 16, 16), new Rectangle(52, 11, 16, 16) };
            var sprite = new AnimatedSprite(link, linkAtlas, sourceRects, .2f, linkScale);
            sprite.Flip = SpriteEffects.FlipHorizontally;

            return sprite;
        }

        public ISprite CreateUpWalkSprite(IGameObject link)
        {
            List<Rectangle> sourceRects = new List<Rectangle> { new Rectangle(69, 11, 16, 16), new Rectangle(86, 11, 16, 16) };
            return new AnimatedSprite(link, linkAtlas, sourceRects, .2f, linkScale);
        }

        public ISprite CreateDownWalkSprite(IGameObject link)
        {
            List<Rectangle> sourceRects = new List<Rectangle> { new Rectangle(1, 11, 16, 16), new Rectangle(18, 11, 16, 16) };
            return new AnimatedSprite(link, linkAtlas, sourceRects, .2f, linkScale);
        }

        /* Attack sprites. */
        public ISprite CreateRightAttackSprite(IGameObject link)
        {
            // Just an animated sprite because each frame's origin is always 0,0

            List<Rectangle> sourceRects = new List<Rectangle> { new Rectangle(1, 77, 16, 16), new Rectangle(18, 77, 27, 16),
                                                                new Rectangle(46, 77, 23, 16), new Rectangle(70, 77, 19, 16)};
            return new AnimatedSprite(link, linkAtlas, sourceRects, attackFrameTime, linkScale);
        }

        public ISprite CreateLeftAttackSprite(IGameObject link)
        {
            List<Rectangle> sourceRects = new List<Rectangle> { new Rectangle(1, 77, 16, 16), new Rectangle(18, 77, 27, 16), 
                                                                new Rectangle(46, 77, 23, 16), new Rectangle(70, 77, 19, 16)};
            List<Vector2> origins = new List<Vector2> { new Vector2(0, 0), new Vector2(11, 0), new Vector2(7, 0), new Vector2(3, 0)};
            var sprite = new VariedOriginsSprite(link, linkAtlas, sourceRects, origins, attackFrameTime, linkScale);
            sprite.Flip = SpriteEffects.FlipHorizontally;

            return sprite;
        }

        public ISprite CreateUpAttackSprite(IGameObject link)
        {
            List<Rectangle> sourceRects = new List<Rectangle> { new Rectangle(1, 109, 16, 16), new Rectangle(18, 97, 16, 28),
                                                                new Rectangle(35, 98, 16, 27), new Rectangle(52, 106, 16, 19)};
            List<Vector2> origins = new List<Vector2> { new Vector2(0, 0), new Vector2(0, 12), new Vector2(0, 11), new Vector2(0, 3) };
            return new VariedOriginsSprite(link, linkAtlas, sourceRects, origins, attackFrameTime, linkScale);
        }

        public ISprite CreateDownAttackSprite(IGameObject link)
        {
            // Just an animated sprite because each frame's origin is always 0,0

            List<Rectangle> sourceRects = new List<Rectangle> { new Rectangle(1, 47, 16, 16), new Rectangle(18, 47, 16, 27), 
                                                                new Rectangle(35, 47, 16, 23), new Rectangle(52, 47, 16, 19) };
            return new AnimatedSprite(link, linkAtlas, sourceRects, attackFrameTime, linkScale);
        }

        /* Item sprites */
        public ISprite CreateRightItemSprite(IGameObject link)
        {
            return new FixedSprite(link, linkAtlas, new Rectangle(124, 11, 16, 16), linkScale);
        }

        public ISprite CreateLeftItemSprite(IGameObject link)
        {
            var sprite = new FixedSprite(link, linkAtlas, new Rectangle(124, 11, 16, 16), linkScale);
            sprite.Flip = SpriteEffects.FlipHorizontally;

            return sprite;
        }

        public ISprite CreateUpItemSprite(IGameObject link)
        {
            return new FixedSprite(link, linkAtlas, new Rectangle(141, 11, 16, 16), linkScale);
        }

        public ISprite CreateDownItemSprite(IGameObject link)
        {
            return new FixedSprite(link, linkAtlas, new Rectangle(107, 11, 16, 16), linkScale);
        }

        public void CreateDamagedLink()
        {
            takeDamageCommand.Execute();
        }
    }
}
