using Microsoft.Xna.Framework;
using Project3902.GameObjects;
using Project3902.LevelBuilding;
using Project3902.ObjectManagement;
using System;
using System.Collections.Generic;
using System.IO;

namespace Project3902
{
    class LevelBuilder : ILevel
    {
        public FinalGame Game { get; }
        private readonly string levelName;
        private readonly EnvironmentFactory envFactory = EnvironmentFactory.Instance;
        private readonly ObjectLookup objectLookup = new ObjectLookup();

        public LevelBuilder(FinalGame game, string levelName)
        {
            Game = game;
            this.levelName = levelName;
        }

        public List<IGameObject> CreateInteractiveEnvironmentObjects()
        {
            var environmentObjects = new List<IGameObject>
            {
                envFactory.CreateRoomBorder(new Vector2(0, 0))
            };

            for (int j = 128; j < 560; j += 64)
            {
                for (int i = 128; i < 839; i += 64)
                {
                    environmentObjects.Add(envFactory.CreateFloorTile(new Vector2(i, j)));
                }
            }

            BuildWalls(environmentObjects);

            var csvReader = new StreamReader($"../../../../LevelBuilding/Levels/{levelName}.csv");
            
            if(csvReader.ReadLine() != "Environment")
            {
                csvReader.Close();
                return environmentObjects;
            }

            while (!csvReader.EndOfStream)
            {
                var line = csvReader.ReadLine();
                var values = line.Split(',');

                if(values[0] == "Items"|| values[0] == "Enemies")
                {
                    break;
                }

                var position = new Vector2(float.Parse(values[1]), float.Parse(values[2]));

                environmentObjects.Add(objectLookup.CreateEnvironmentObject(values[0], position));
            }

            csvReader.Close();

            return environmentObjects;
        }

        public List<IGameObject> CreateItemObjects()
        {
            var itemObjects = new List<IGameObject>();

            var csvReader = new StreamReader($"../../../../LevelBuilding/Levels/{levelName}.csv");

            while (csvReader.ReadLine() != "Items")
            {
                if (csvReader.EndOfStream)
                {
                    csvReader.Close();
                    return itemObjects;
                }
            }

            while (!csvReader.EndOfStream)
            {
                var line = csvReader.ReadLine();
                var values = line.Split(',');

                if (values[0] == "Enemies")
                {
                    break;
                }

                var position = new Vector2(float.Parse(values[1]), float.Parse(values[2]));

                itemObjects.Add(objectLookup.CreateItemObject(values[0], position));
            }

            csvReader.Close();

            return itemObjects;
        }

    

        public List<IGameObject> CreateEnemyObjects()
        {
            var enemyObjects = new List<IGameObject>();

            var csvReader = new StreamReader($"../../../../LevelBuilding/Levels/{levelName}.csv");

            while(csvReader.ReadLine() != "Enemies")
            {
                if(csvReader.EndOfStream)
                {
                    csvReader.Close();
                    return enemyObjects;
                }
            }

            while (!csvReader.EndOfStream)
            {
                var line = csvReader.ReadLine();
                var values = line.Split(',');

                if (values[0] == "Levels")
                {
                    break;
                }

                var position = new Vector2(float.Parse(values[1]), float.Parse(values[2]));

                enemyObjects.Add(objectLookup.CreateEnemyObject(values[0], position));
            }

            csvReader.Close();

            return enemyObjects;
        }

        public LevelMap CreateAdjacentLevels()
        {
            var level = new LevelMap("", "", "", "");

            var csvReader = new StreamReader($"../../../../LevelBuilding/Levels/{levelName}.csv");

            while (csvReader.ReadLine() != "Levels")
            {
                if (csvReader.EndOfStream)
                {
                    csvReader.Close();
                    return level;
                }
            }

            while (!csvReader.EndOfStream)
            {
                var line = csvReader.ReadLine();
                var values = line.Split(',');
                string levelName = values[1].Trim();

                if (values[0] == "Top")
                {
                    level.Top = levelName;
                } 
                else if(values[0] == "Left")
                {
                    level.Left = levelName;
                }
                else if (values[0] == "Right")
                {
                    level.Right = levelName;
                }
                else if (values[0] == "Bottom")
                {
                    level.Bottom = levelName;
                }
                else
                {
                    throw new Exception($"The object {values[1]} has not been mapped in ObjectLookup yet!");
                }
            }

            csvReader.Close();

            return level;
        }

        private void BuildWalls(List<IGameObject> envList)
        {
            var TopLeft1 = new BlankWallObject(new Vector2(0, 0));
            TopLeft1.Collider = new Collider(TopLeft1, new Rectangle(0, 0, 128, 288));
            CollisionHandler.Instance.RegisterCollidable(TopLeft1, Layer.Wall);

            var TopLeft2 = new BlankWallObject(new Vector2(0, 0));
            TopLeft2.Collider = new Collider(TopLeft2, new Rectangle(0, 0, 448, 128));
            CollisionHandler.Instance.RegisterCollidable(TopLeft2, Layer.Wall);

            var TopRight1 = new BlankWallObject(new Vector2(576, 0));
            TopRight1.Collider = new Collider(TopRight1, new Rectangle(0, 0, 448, 128));
            CollisionHandler.Instance.RegisterCollidable(TopRight1, Layer.Wall);

            var TopRight2 = new BlankWallObject(new Vector2(896, 0));
            TopRight2.Collider = new Collider(TopRight2, new Rectangle(0, 0, 128, 288));
            CollisionHandler.Instance.RegisterCollidable(TopRight2, Layer.Wall);

            var BottomLeft1 = new BlankWallObject(new Vector2(0, 416));
            BottomLeft1.Collider = new Collider(BottomLeft1, new Rectangle(0, 0, 128, 288));
            CollisionHandler.Instance.RegisterCollidable(BottomLeft1, Layer.Wall);

            var BottomLeft2 = new BlankWallObject(new Vector2(0, 576));
            BottomLeft2.Collider = new Collider(BottomLeft2, new Rectangle(0, 0, 448, 128));
            CollisionHandler.Instance.RegisterCollidable(BottomLeft2, Layer.Wall);

            var BottomRight1 = new BlankWallObject(new Vector2(576, 576));
            BottomRight1.Collider = new Collider(BottomRight1, new Rectangle(0, 0, 448, 128));
            CollisionHandler.Instance.RegisterCollidable(BottomRight1, Layer.Wall);

            var BottomRight2 = new BlankWallObject(new Vector2(896, 416));
            BottomRight2.Collider = new Collider(BottomRight2, new Rectangle(0, 0, 128, 288));
            CollisionHandler.Instance.RegisterCollidable(BottomRight2, Layer.Wall);

            envList.AddRange(new IGameObject[] { TopLeft1, TopLeft2, TopRight1, TopRight2, BottomLeft1, BottomLeft2, BottomRight1, BottomRight2 });
        }

       

    }
}
