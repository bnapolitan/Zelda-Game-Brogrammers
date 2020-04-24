using Microsoft.Xna.Framework.Graphics;
using Project3902.Configuration;
using System.Collections.Generic;

namespace Project3902
{
    class GameOverState
    {
        private FinalGame game;
        public List<IDrawable> ScreenElements = new List<IDrawable>();
        private HUDFactory Factory = HUDFactory.Instance;
        public static GameOverState Instance { get; } = new GameOverState();
        private GameOverState()
        {
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IDrawable obj in ScreenElements)
            {
                obj.Draw(spriteBatch);
            }
        }

        public void RegisterGame(FinalGame game)
        {
            this.game = game;
            createElements();
        }

        private void createElements()
        {

            ScreenElements.Add(Factory.createTextSection(game.font, "Game Over!\n"));
            ScreenElements.Add(Factory.createExitText(game.font, TextConfiguration.GameOverMenuText));
        }
    }
}
