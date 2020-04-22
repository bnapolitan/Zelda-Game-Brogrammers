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

        public KeyboardController CreateLinkController(FinalGame game)
        {
            var controller = new KeyboardController();


            controller.RegisterCommand(Keys.Up, new LinkMoveUpCommand(game));
            controller.RegisterCommand(Keys.Down, new LinkMoveDownCommand(game));
            controller.RegisterCommand(Keys.Left, new LinkMoveLeftCommand(game));
            controller.RegisterCommand(Keys.Right, new LinkMoveRightCommand(game));
            controller.RegisterCommand(Keys.W, new LinkMoveUpCommand(game));
            controller.RegisterCommand(Keys.S, new LinkMoveDownCommand(game));
            controller.RegisterCommand(Keys.A, new LinkMoveLeftCommand(game));
            controller.RegisterCommand(Keys.D, new LinkMoveRightCommand(game));

            controller.RegisterCommand(Keys.Z, new LinkAttackCommand(game), InputState.Pressed);
            controller.RegisterCommand(Keys.N, new LinkAttackCommand(game), InputState.Pressed);

            controller.RegisterCommand(Keys.D1, new LinkUseBoomerangCommand(game), InputState.Pressed);
            controller.RegisterCommand(Keys.D2, new LinkUseBlueCandleCommand(game), InputState.Pressed);
            controller.RegisterCommand(Keys.D3, new LinkUseBombCommand(game), InputState.Pressed);

            controller.RegisterCommand(Keys.G, new PauseGameCommand(game), InputState.Pressed);
            controller.RegisterCommand(Keys.LeftShift, new LinkSpeedUpCommand(game), InputState.Pressed);
            controller.RegisterCommand(Keys.LeftShift, new LinkSlowDownCommand(game), InputState.Released);
            controller.RegisterCommand(Keys.RightShift, new LinkSpeedUpCommand(game), InputState.Pressed);
            controller.RegisterCommand(Keys.RightShift, new LinkSlowDownCommand(game), InputState.Released);

            return controller;
        }

        public GamepadController CreateLinkGamepadController(FinalGame game)
        {
            var controller = new GamepadController();

            controller.RegisterCommand(Buttons.DPadUp, new LinkMoveUpCommand(game));
            controller.RegisterCommand(Buttons.DPadDown, new LinkMoveDownCommand(game));
            controller.RegisterCommand(Buttons.DPadLeft, new LinkMoveLeftCommand(game));
            controller.RegisterCommand(Buttons.DPadRight, new LinkMoveRightCommand(game));


            controller.RegisterCommand(Buttons.A, new LinkAttackCommand(game), InputState.Pressed);
            controller.RegisterCommand(Buttons.B, new LinkAttackCommand(game), InputState.Pressed);

            controller.RegisterCommand(Buttons.LeftTrigger, new LinkUseBoomerangCommand(game), InputState.Pressed);
            controller.RegisterCommand(Buttons.RightTrigger, new LinkUseBlueCandleCommand(game), InputState.Pressed);


            controller.RegisterCommand(Buttons.Start, new PauseGameCommand(game), InputState.Pressed);
            controller.RegisterCommand(Buttons.LeftThumbstickDown, new LinkSpeedUpCommand(game), InputState.Pressed);
            controller.RegisterCommand(Buttons.LeftThumbstickDown, new LinkSlowDownCommand(game), InputState.Released);
            controller.RegisterCommand(Buttons.RightThumbstickDown, new LinkSpeedUpCommand(game), InputState.Pressed);
            controller.RegisterCommand(Buttons.RightThumbstickDown, new LinkSlowDownCommand(game), InputState.Released);

            return controller;
        }

        public ISprite CreateRightWalkSprite(IGameObject link)
        {
            List<Rectangle> sourceRects = new List<Rectangle> { new Rectangle(35, 11, 16, 16), new Rectangle(52, 11, 16, 16) };
            return new AnimatedSprite(link, linkAtlas, sourceRects, .2f, linkScale);
        }

        public ISprite CreateLeftWalkSprite(IGameObject link)
        {
            List<Rectangle> sourceRects = new List<Rectangle> { new Rectangle(35, 11, 16, 16), new Rectangle(52, 11, 16, 16) };
            var sprite = new AnimatedSprite(link, linkAtlas, sourceRects, .2f, linkScale)
            {
                Flip = SpriteEffects.FlipHorizontally
            };

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


        public ISprite CreateRightAttackSprite(IGameObject link)
        {


            List<Rectangle> sourceRects = new List<Rectangle> { new Rectangle(1, 77, 16, 16), new Rectangle(18, 77, 27, 16),
                                                                new Rectangle(46, 77, 23, 16), new Rectangle(70, 77, 19, 16)};
            return new AnimatedSprite(link, linkAtlas, sourceRects, attackFrameTime, linkScale);
        }

        public ISprite CreateLeftAttackSprite(IGameObject link)
        {
            List<Rectangle> sourceRects = new List<Rectangle> { new Rectangle(1, 77, 16, 16), new Rectangle(18, 77, 27, 16),
                                                                new Rectangle(46, 77, 23, 16), new Rectangle(70, 77, 19, 16)};
            List<Vector2> origins = new List<Vector2> { new Vector2(0, 0), new Vector2(11, 0), new Vector2(7, 0), new Vector2(3, 0)};
            var sprite = new VariedOriginsSprite(link, linkAtlas, sourceRects, origins, attackFrameTime, linkScale)
            {
                Flip = SpriteEffects.FlipHorizontally
            };

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


            List<Rectangle> sourceRects = new List<Rectangle> { new Rectangle(1, 47, 16, 16), new Rectangle(18, 47, 16, 27),
                                                                new Rectangle(35, 47, 16, 23), new Rectangle(52, 47, 16, 19) };
            return new AnimatedSprite(link, linkAtlas, sourceRects, attackFrameTime, linkScale);
        }


        public ISprite CreateRightItemSprite(IGameObject link)
        {
            return new FixedSprite(link, linkAtlas, new Rectangle(124, 11, 16, 16), linkScale);
        }

        public ISprite CreateLeftItemSprite(IGameObject link)
        {
            var sprite = new FixedSprite(link, linkAtlas, new Rectangle(124, 11, 16, 16), linkScale)
            {
                Flip = SpriteEffects.FlipHorizontally
            };

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
