using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class PauseScreen
    {
        private FinalGame game;
        public List<IGameObject> PauseScreenElements = new List<IGameObject>();
        private HUDFactory Factory = HUDFactory.Instance;
        public static PauseScreen Instance { get; } = new PauseScreen();
        private PauseScreen()
        {
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(IGameObject obj in PauseScreenElements)
            {
                obj.Draw(spriteBatch);
            }
        }

        public void registerGame(FinalGame game)
        {
            this.game = game;
            createPauseElements();
        }

        public void createPauseElements()
        {
            PauseScreenElements.Add(Factory.createPauseInventorySection());
            PauseScreenElements.Add(Factory.createPauseMapSection());
        }
    }
}
