using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

/* 
 * Team:
 * Dan Bellini
 * Huang Huang
 * Xueyang Li
 * Ben Napolitan
 * Austin Rogers
 * Suraj Suresh
*/

namespace Project3902
{
    public class Sprint0 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private IController<Keys> keyboardController;
        private IController<MouseActions> mouseController;

        private SpriteAtlas linkAtlas;
        private Texture2D linkTexture;

        private SpriteFont creditsFont;
        private Color creditsColor;

        private List<ITextSprite> texts;

        private IGameObject gameObject;

        private ISprite nonmovingNonanimatedSprite;
        private ISprite nonmovingAnimatedSprite;
        private ISprite movingNonanimatedSprite;
        private ISprite movingAnimatedSprite;

        private ITextSprite creditsText;
        private ITextSprite nameText;
        private ITextSprite sourceText;

        private Vector2 spriteScale = new Vector2(4, 4);

        public Sprint0()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;

            SetUpMouseController();
            SetUpKeyboardController();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            CreateSprites();
            CreateText();
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            keyboardController.Update();
            mouseController.Update();

            gameObject.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            gameObject.Draw(spriteBatch);

            foreach (ITextSprite text in texts)
                text.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void SetUpMouseController()
        {
            mouseController = new MouseController();

            mouseController.RegisterCommand(MouseActions.Left, new SetSpriteMouseCommand(this));
            //mouseController.RegisterCommand(MouseActions.Right, new ExitGameCommand(this));
        }

        private void SetUpKeyboardController()
        {
            keyboardController = new KeyboardController();

            keyboardController.RegisterCommand(Keys.D1, new SetNonmovingNonanimatedCommand(this));
            keyboardController.RegisterCommand(Keys.NumPad1, new SetNonmovingNonanimatedCommand(this));

            keyboardController.RegisterCommand(Keys.D2, new SetNonmovingAnimatedCommand(this));
            keyboardController.RegisterCommand(Keys.NumPad2, new SetNonmovingAnimatedCommand(this));

            keyboardController.RegisterCommand(Keys.D3, new SetMovingNonanimatedCommand(this));
            keyboardController.RegisterCommand(Keys.NumPad3, new SetMovingNonanimatedCommand(this));

            keyboardController.RegisterCommand(Keys.D4, new SetMovingAnimatedCommand(this));
            keyboardController.RegisterCommand(Keys.NumPad4, new SetMovingAnimatedCommand(this));

            //keyboardController.RegisterCommand(Keys.D0, new ExitGameCommand(this));
            //keyboardController.RegisterCommand(Keys.NumPad0, new ExitGameCommand(this));
        }

        private void CreateSprites()
        {
            gameObject = new FixedGameObject(new Vector2(368, 208));

            linkTexture = Content.Load<Texture2D>("linkspritesheet");
            linkAtlas = new SpriteAtlas(linkTexture);

            nonmovingNonanimatedSprite = new FixedSprite(gameObject, linkAtlas, new Rectangle(306, 11, 16, 16), spriteScale);

            List<Rectangle> nonmovingAnimatedSource = new List<Rectangle> { new Rectangle(280, 77, 16, 16), new Rectangle(297, 77, 27, 16), new Rectangle(325, 77, 23, 16), new Rectangle(349, 77, 19, 16) };
            nonmovingAnimatedSprite = new AnimatedSprite(gameObject, linkAtlas, nonmovingAnimatedSource, .15f, spriteScale);

            movingNonanimatedSprite = new CircleMoveSprite(gameObject, linkAtlas, new Rectangle(230, 11, 16, 16), 20, 2, spriteScale);

            List<Rectangle> movingAnimatedSource = new List<Rectangle> { new Rectangle(35, 11, 16, 16), new Rectangle(52, 11, 16, 16) };
            movingAnimatedSprite = new BackAndForthSprite(gameObject, linkAtlas, movingAnimatedSource, .2f, 20, 20, spriteScale);

            SetNonmovingNonanimatedSprite();
        }

        private void CreateText()
        {
            creditsFont = Content.Load<SpriteFont>("Credits");
            creditsColor = Color.AntiqueWhite;

            creditsText = new SimpleText("Credits", new Vector2(400, 400), creditsColor, creditsFont, true);
            nameText = new SimpleText("Made by: Austin Rogers.1274", new Vector2(400, 420), creditsColor, creditsFont, true);

            string sourceString = "Sprites from: https://www.spriters-resource.com/nes/legendofzelda/sheet/8366/";
            sourceText = new SimpleText(sourceString, new Vector2(400, 440), creditsColor, creditsFont, true);

            texts = new List<ITextSprite> { creditsText, nameText, sourceText };
        }

        public void SetNonmovingNonanimatedSprite()
        {
            gameObject.Sprite = nonmovingNonanimatedSprite;
        }

        public void SetNonmovingAnimatedSprite()
        {
            gameObject.Sprite = nonmovingAnimatedSprite;
        }

        public void SetMovingNonanimatedSprite()
        {
            gameObject.Sprite = movingNonanimatedSprite;
        }

        public void SetMovingAnimatedSprite()
        {
            gameObject.Sprite = movingAnimatedSprite;
        }
    }
}
