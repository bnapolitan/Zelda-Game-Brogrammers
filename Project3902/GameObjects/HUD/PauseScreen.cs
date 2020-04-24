using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Project3902
{
    class PauseScreen
    {
        private FinalGame game;
        private Vector2 PauseScale = new Vector2(4, 4);
        private IGameObject SelectedItem;
        private readonly Vector2 SelectedItemPos = new Vector2(280, 220);
        public List<IGameObject> PauseScreenElements = new List<IGameObject>();
        private List<List<IGameObject>> InventoryMapMatrix = new List<List<IGameObject>>();
        private IGameObject mapBlip;
        private readonly IDictionary<string, Vector2> roomMapMatrix;
        private readonly IDictionary<string, int> mapRoomValues;
        private string lastRoom = "none";
        private IGameObject ItemSelector;
        private readonly HUDFactory Factory = HUDFactory.Instance;
        private List<IGameObject> aquiredItems = new List<IGameObject>();
        private List<String> aquiredObjectKeys = new List<String>();
        private int numItemsAquired = 0;
        private int SelectorPos = 0;

        public static PauseScreen Instance { get; } = new PauseScreen();
        private PauseScreen()
        {
            roomMapMatrix = CreateMapRoomMatrixDictionary();
            mapRoomValues = CreateMapRoomTypeDictionary();
        }

        public void Update()
        {
            if (!Equals(lastRoom, game.CurrentRoom))
            {
                UpdateInventoryMap();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IGameObject obj in PauseScreenElements)
            {
                obj.Draw(spriteBatch);
            }
            if(ItemSelector != null)
            {
                ItemSelector.Draw(spriteBatch);
            }
            SelectedItem.Draw(spriteBatch);
            foreach(List<IGameObject> list in InventoryMapMatrix)
            {
                foreach(IGameObject gameObject in list)
                {
                    gameObject.Draw(spriteBatch);
                }
            }
            mapBlip.Draw(spriteBatch);

        }

        public void RegisterGame(FinalGame game)
        {
            this.game = game;
            CreatePauseElements();
        }

        public void CreatePauseElements()
        {
            PauseScreenElements.Add(Factory.CreatePauseInventorySection());
            PauseScreenElements.Add(Factory.CreatePauseMapSection());
            PauseScreenElements.Add(Factory.CreateBlackInventoryBox());
            PauseScreenElements.Add(Factory.CreateTopInventoryBlackBar());
            PauseScreenElements.Add(Factory.CreateItemBlackBox());
            PauseScreenElements.Add(Factory.CreateCompassBlackBox());
            PauseScreenElements.Add(Factory.CreateLowerPauseBorder());
            PauseScreenElements.Add(Factory.CreateSidePauseBorder());
            FillMapBlocks();
            var blackBox = Factory.CreateItemBlackBox();
            blackBox.Position = new Vector2(270, 210);
            PauseScreenElements.Add(blackBox);

            
            
            SelectedItem = Factory.CreateItemBlackBox();
            SelectedItem.Position = new Vector2(280, 210);

            
        }

        private void FillMapBlocks()
        {
            var baseVector = new Vector2(512, 404);
            for(int i = 0; i < 8; i++)
            {
                InventoryMapMatrix.Add(new List<IGameObject>());
                for(int j = 0; j < 8; j++)
                {

                    InventoryMapMatrix[i].Add(Factory.CreateSolidMapBlock(new Vector2(baseVector.X + (i*32), baseVector.Y + (j*32))));
                }
            }
        }

        private void UpdateInventoryMap()
        {
            var roomMapValue = mapRoomValues[game.CurrentRoom];
            var roomMatrixPos = roomMapMatrix[game.CurrentRoom];
            InventoryMapMatrix[(int)roomMatrixPos.X][(int)roomMatrixPos.Y] = Factory.CreateMapRoomBlock(new Vector2((512 + ((int)roomMatrixPos.X) * 32), (404 + ((int)roomMatrixPos.Y) * 32)), roomMapValue);
            mapBlip = Factory.CreateMapBlip();
            mapBlip.Sprite.Scale = PauseScale;
            var temp = InventoryMapMatrix[(int)roomMatrixPos.X][(int)roomMatrixPos.Y].Position;
            temp.X += 9;
            temp.Y += 9;
            mapBlip.Position = temp;
            

        }
        public void AddMapToPauseScreen()
        {
 
            PauseScreenElements.Add(Factory.CreatePauseMap(new Vector2(180, 460)));

        }

        public void AddCompassToPauseScreen()
        {
            PauseScreenElements.Add(Factory.CreatePauseCompass(new Vector2(180, 620)));
        }


        public void AddToAquiredItems(IGameObject item)
        {
            bool aquired = false;


                if (item is Bow)
                {
                    
                    foreach (IGameObject collected in aquiredItems)
                    {
                        if (collected is Bow)
                        {
                            aquired = true;
                        }
                        
                    }
                    if (aquired == false)
                    {
                        PauseScreenElements.Add(Factory.CreateHUDBow(CalculateNextInventoryPosition()));
                        aquiredItems.Add(item);
                        aquiredObjectKeys.Add("Bow");
                        numItemsAquired++;
                        
                    }
                }
                if (item is Arrow)
                {
                    
                    foreach (IGameObject collected in aquiredItems)
                    {
                        if (collected is Arrow)
                        {
                            aquired = true;
                        }
                        
                    }
                    if (aquired == false)
                    {
                        PauseScreenElements.Add(Factory.CreateHUDArrow(CalculateNextInventoryPosition()));
                        aquiredItems.Add(item);
                        aquiredObjectKeys.Add("Arrow");
                        numItemsAquired++;
                        
                    }
                }
                if (item is Candle)
                {
                    foreach (IGameObject collected in aquiredItems)
                    {
                        if (collected is Candle)
                        {
                            aquired = true;
                        }
                       
                    }
                    if (aquired == false)
                    {
                        PauseScreenElements.Add(Factory.CreateHUDCandle(CalculateNextInventoryPosition()));
                        aquiredItems.Add(item);
                        aquiredObjectKeys.Add("Candle");
                        numItemsAquired++;
                        
                    }
                }
            if (item is BoomerangItem)
            {
                foreach (IGameObject collected in aquiredItems)
                {
                    if (collected is BoomerangItem)
                    {
                        aquired = true;
                    }

                }
                if (aquired == false)
                {
                    PauseScreenElements.Add(Factory.CreateHUDBoomerang(CalculateNextInventoryPosition()));
                    aquiredItems.Add(item);
                    aquiredObjectKeys.Add("Boomerang");
                    numItemsAquired++;

                }
            }
            if (item is BombPickup)
            {
                foreach (IGameObject collected in aquiredItems)
                {
                    if (collected is BombPickup)
                    {
                        aquired = true;
                    }

                }
                if (aquired == false)
                {
                    PauseScreenElements.Add(Factory.CreateHUDBomb(CalculateNextInventoryPosition()));
                    aquiredItems.Add(item);
                    aquiredObjectKeys.Add("Bomb");
                    numItemsAquired++;

                }
            }
            if(numItemsAquired == 1)
            {
                ItemSelector = Factory.CreateItemSelector(new Vector2(510, 220));
                SelectItem();
            }



        }

        public Vector2 CalculateNextInventoryPosition()
        {
            Vector2 baseVector = new Vector2(525, 220);
            baseVector.X += (numItemsAquired % 4) * 100;
            baseVector.Y += (numItemsAquired / 4) * 75;
            return baseVector;
            
        }

        public Vector2 CalculateItemSelectorPosition()
        {
            Vector2 baseVector = new Vector2(510, 220);
            baseVector.X += Math.Abs((SelectorPos % 4) * 100);
            baseVector.Y += Math.Abs(((SelectorPos / 4) % 2) * 75);
            return baseVector;
        }


        public void MoveSelectorUp()
        {
            var temp = SelectorPos;
            temp -= 4;
            if (temp >= 0 && temp < numItemsAquired)
            {

                SelectorPos -= 4;
                ItemSelector.Position = CalculateItemSelectorPosition();
            }
        }

        public void MoveSelectorDown()
        {
            var temp = SelectorPos;
            temp += 4;
            if (temp >= 0 && temp < numItemsAquired)
            {

                SelectorPos += 4;
                ItemSelector.Position = CalculateItemSelectorPosition();
            }
        }

        public void MoveSelectorLeft()
        {
            var temp = SelectorPos;
            temp -= 1;
            if (temp >= 0 && temp < numItemsAquired)
            {

                SelectorPos -= 1;
                ItemSelector.Position = CalculateItemSelectorPosition();
            }
        }

        public void MoveSelectorRight()
        {
            var temp = SelectorPos;
            temp += 1;
            if (temp >= 0 && temp < numItemsAquired)
            {

                SelectorPos += 1;
                ItemSelector.Position = CalculateItemSelectorPosition();
            }
        }

 
        private IDictionary<string, Vector2> CreateMapRoomMatrixDictionary()
        {
            var dictionary = new Dictionary<string, Vector2>
            {
                { "SurvivalRoom", new Vector2(2,7) },
                { "BulletHellRoom", new Vector2(4,7) },
                { "DungeonRoom0",  new Vector2(3,7)},
                { "DungeonRoom1",  new Vector2(3,6)},
                { "DungeonRoom2",  new Vector2(2,6)},
                { "DungeonRoom3",  new Vector2(4,6)},
                { "DungeonRoom4",  new Vector2(3,5)},
                { "DungeonRoom5",  new Vector2(3,4)},
                { "DungeonRoom6",  new Vector2(2,4)},
                { "DungeonRoom7",  new Vector2(4,4)},
                { "DungeonRoom8",  new Vector2(2,3)},
                { "DungeonRoom9",  new Vector2(1,3)},
                { "DungeonRoom10", new Vector2(3,3) },
                { "DungeonRoom11",  new Vector2(3,2)},
                { "DungeonRoom12",  new Vector2(3,1)},
                { "DungeonRoom13",  new Vector2(2,1)},
                { "DungeonRoom14",  new Vector2(4,3)},
                { "DungeonRoom15", new Vector2(5,3)},
                { "DungeonRoom16",  new Vector2(5,2)},
                { "DungeonRoom17",  new Vector2(6,2)}
            };


            return dictionary;
        }

        private IDictionary<string, int> CreateMapRoomTypeDictionary()
        {
            var dictionary = new Dictionary<string, int>
            {
                { "SurvivalRoom", 1 },
                { "BulletHellRoom", 2 },
                { "DungeonRoom0",  11},
                { "DungeonRoom1",  11},
                { "DungeonRoom2",  1},
                { "DungeonRoom3",  2},
                { "DungeonRoom4",  12},
                { "DungeonRoom5",  7},
                { "DungeonRoom6",  9},
                { "DungeonRoom7",  2},
                { "DungeonRoom8",  7},
                { "DungeonRoom9",  1},
                { "DungeonRoom10", 11},
                { "DungeonRoom11",  12},
                { "DungeonRoom12",  6},
                { "DungeonRoom13",  1},
                { "DungeonRoom14",  3},
                { "DungeonRoom15", 10},
                { "DungeonRoom16",  5},
                { "DungeonRoom17",  2}
            };


            return dictionary;
        }
        public void SelectItem()
        {
            if (aquiredItems.Count>0)
            {
                var selectedItem = aquiredItems[SelectorPos];
                if (selectedItem is Sword)
                {
                    SelectedItem = Factory.CreateHUDSword(SelectedItemPos);
                    HUDManager.Instance.ChangeBItem(Factory.CreateHUDSword(SelectedItemPos), selectedItem);
                }
                if (selectedItem is BoomerangItem)
                {
                    SelectedItem = Factory.CreateHUDBoomerang(SelectedItemPos);
                    HUDManager.Instance.ChangeBItem(Factory.CreateHUDBoomerang(SelectedItemPos), selectedItem);
                }
                if (selectedItem is Arrow)
                {
                    SelectedItem = Factory.CreateHUDArrow(SelectedItemPos);
                    HUDManager.Instance.ChangeBItem(Factory.CreateHUDArrow(SelectedItemPos), selectedItem);
                }
                if (selectedItem is Candle)
                {
                    SelectedItem = Factory.CreateHUDCandle(SelectedItemPos);
                    HUDManager.Instance.ChangeBItem(Factory.CreateHUDCandle(SelectedItemPos), selectedItem);
                }
                if (selectedItem is Bow)
                {
                    SelectedItem = Factory.CreateHUDBow(SelectedItemPos);
                    HUDManager.Instance.ChangeBItem(Factory.CreateHUDBow(SelectedItemPos), selectedItem);
                }
                if (selectedItem is BombPickup)
                {
                    SelectedItem = Factory.CreateHUDBomb(SelectedItemPos);
                    HUDManager.Instance.ChangeBItem(Factory.CreateHUDBomb(SelectedItemPos), selectedItem);
                }
            }
        }

        public void ExitGame()
        {
            game.Exit();
        }

        public void Reset()
        {
            aquiredItems.Clear();
            PauseScreenElements.Clear();
            CreatePauseElements();
            InventoryMapMatrix.Clear();
            FillMapBlocks();
            numItemsAquired = 0;
            ItemSelector = null;
        }

    }
    
    
}
