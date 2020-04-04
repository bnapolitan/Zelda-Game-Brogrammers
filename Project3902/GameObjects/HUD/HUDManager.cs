
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class HUDManager
    {
        private FinalGame game;
        public List<IGameObject> HUDElements = new List<IGameObject>();
        public List<IGameObject> HeartsList = new List<IGameObject>();
        private HUDFactory Factory = HUDFactory.Instance;
        public static HUDManager Instance { get; } = new HUDManager();
        private int numHearts;
        private int maxHearts;
        
        private HUDManager()
        {   
        }

        public void Update(GameTime gameTime)
        {
            numHearts = (int) game.Link.Health;
            maxHearts = (int) game.Link.MaxHealth;
            updateHearts();
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(IGameObject gameObject in HUDElements){
                gameObject.Draw(spriteBatch);
            }

            foreach(IGameObject gameObject in HeartsList)
            {
                gameObject.Draw(spriteBatch);
            }
        }

        public void registerGame(FinalGame game)
        {
            this.game = game;
            addBaseElements();
        }

        private void addBaseElements()
        {
            HUDElements.Add(Factory.createLifeWord());
            HUDElements.Add(Factory.createCoinCountIcon());
            HUDElements.Add(Factory.createOrbCountIcon());
            HUDElements.Add(Factory.createKeyCountIcon());
            HUDElements.Add(Factory.createLevelWord());
            HUDElements.Add(Factory.createABox());
            HUDElements.Add(Factory.createBBox());
        }

        private void updateHearts()
        {
            var heartsCreated = 0;
            Console.WriteLine("MAX:" + maxHearts + "\n");
            Console.WriteLine("NUM: " + numHearts + "\n");

            HeartsList.Clear();
            while (heartsCreated + 2 <= numHearts)
            {
                var heart = Factory.createFullHeart();
                var tempPos = heart.Position;
                tempPos.X = heart.Position.X + (heartsCreated / 2) * 8 * heart.Sprite.Scale.X;
                heart.Position = tempPos;
                HeartsList.Add(heart);
                heartsCreated += 2;
            }
            if(numHearts%2 == 1)
            {
                var heart = Factory.createHalfHeart();
                var tempPos = heart.Position;
                tempPos.X = heart.Position.X + (heartsCreated / 2) * 8 * heart.Sprite.Scale.X;
                heart.Position = tempPos;
                HeartsList.Add(heart);
                heartsCreated += 2;
            }
            while(heartsCreated < maxHearts)
            {
                var heart = Factory.createEmptyHeart();
                var tempPos = heart.Position;
                tempPos.X = heart.Position.X + (heartsCreated / 2) * 8 * heart.Sprite.Scale.X;
                heart.Position = tempPos;
                HeartsList.Add(heart);
                heartsCreated += 2;
            }

            
        }


    }
}
